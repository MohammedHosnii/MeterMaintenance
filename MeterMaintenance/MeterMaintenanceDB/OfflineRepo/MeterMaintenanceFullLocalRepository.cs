using Dapper;
using MeterMaintenanceDB.OfflineModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MeterMaintenanceDB.OfflineRepo
{


    
    public class MeterMaintenanceFullLocalRepository
    {
        private readonly IDbConnection _db;

        public MeterMaintenanceFullLocalRepository(IDbConnection db)
        {
            _db = db;
        }

        // =====================================================
        // SAVE HEADER + DETAILS
        // =====================================================
        public async Task SaveAsync(MeterMaintenanceFullLocalDto model)
        {
            if (_db.State != ConnectionState.Open)
                _db.Open();

            using (var tran = _db.BeginTransaction())
            {
                try
                {
                    model.Header.MaintenanceRecordCode =
                    long.Parse(DateTime.Now.ToString("yyyyMMddHHmmssfff") + SystemInfo.userId.ToString())
                     ;
                    model.Header.UserId = SystemInfo.userId;
                    // ---------- HEADER ----------
                    string headerSql = @"
                    INSERT INTO MaintenanceRecord
                    (
                        MaintenanceRecordDate,
                        CompanySectorDept_Id,
                        LabCenter_Id,
                        MeterCount,
                        WorkingMetersCount,
                        RepairedMetersCount,
                        RetiredMetersCount,
                        MaintenanceRecordCode,
                        ISSync,
                        CompanySectorDept_Level,
                        UserId
                    )
                    VALUES
                    (
                        @MaintenanceRecordDate,
                        @CompanySectorDept_Id,
                        @LabCenter_Id,
                        @MeterCount,
                        @WorkingMetersCount,
                        @RepairedMetersCount,
                        @RetiredMetersCount,
                        @MaintenanceRecordCode,
                        @ISSync,
                        @CompanySectorDept_Level,
                        @UserId
                    );";

                    await _db.ExecuteAsync(headerSql, model.Header, tran);

                    // ---------- DETAILS ----------
                    string detailSql = @"
                    INSERT INTO MaintenanceRecord_Detail
                    (
                        MaintenanceRecordCode,
                        MeterNumber,
                        TestResultCode,
                        CorrectiveActionCode,
                        ISSync
                    )
                    VALUES
                    (
                        @MaintenanceRecordCode,
                        @MeterNumber,
                        @TestResultCode,
                        @CorrectiveActionCode,
                        @ISSync
                    );";

                    foreach (var d in model.Details)
                    {
                        // link to header
                        d.MaintenanceRecordCode =
                            model.Header.MaintenanceRecordCode.ToString();

                        await _db.ExecuteAsync(detailSql, d, tran);
                    }

                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }



        public async Task SyncFromServerToLocal(MeterMaintenanceFullLocalDto model)
        {
            using (SqlConnection con = SystemInfo.Connection_Local)
            {
                if (con.State == ConnectionState.Closed)
                    await con.OpenAsync();

                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = con.CreateCommand())
                        {
                            cmd.Transaction = transaction;
                            cmd.CommandType = CommandType.Text;

                            // ================= HEADER MERGE =================
                            cmd.CommandText = @"
                        MERGE MeterMaintenance_LocalDB.dbo.MaintenanceRecord AS T
                        USING ServerDB.MeterMaintenanceDB.dbo.MaintenanceRecord AS S
                        ON T.MaintenanceRecordCode = S.MaintenanceRecordCode

                        WHEN MATCHED THEN
                        UPDATE SET
                            T.MaintenanceRecordDate   = S.MaintenanceRecordDate,
                            T.CompanySectorDept_Id    = S.CompanySectorDept_Id,
                            T.LabCenter_Id            = S.LabCenter_Id,
                            T.MeterCount              = S.MeterCount,
                            T.WorkingMetersCount      = S.WorkingMetersCount,
                            T.RepairedMetersCount     = S.RepairedMetersCount,
                            T.RetiredMetersCount      = S.RetiredMetersCount,
                            T.CompanySectorDept_Level = S.CompanySectorDept_Level,
                            T.ISSync = 1

                        WHEN NOT MATCHED THEN
                        INSERT (
                            MaintenanceRecordDate,
                            CompanySectorDept_Id,
                            LabCenter_Id,
                            MeterCount,
                            WorkingMetersCount,
                            RepairedMetersCount,
                            RetiredMetersCount,
                            MaintenanceRecordCode,
                            CompanySectorDept_Level,
                            ISSync,
                            UserId
                        )
                        VALUES (
                            S.MaintenanceRecordDate,
                            S.CompanySectorDept_Id,
                            S.LabCenter_Id,
                            S.MeterCount,
                            S.WorkingMetersCount,
                            S.RepairedMetersCount,
                            S.RetiredMetersCount,
                            S.MaintenanceRecordCode,
                            S.CompanySectorDept_Level,
                            1,
                            S.UserId
                        );";

                            await cmd.ExecuteNonQueryAsync();

                            // ================= DETAILS MERGE =================
                            cmd.CommandText = @"
                        MERGE MeterMaintenance_LocalDB.dbo.MaintenanceRecord_Detail AS T
                        USING ServerDB.MeterMaintenanceDB.dbo.MaintenanceRecord_Detail AS S
                        ON T.MaintenanceRecordCode = S.MaintenanceRecordCode
                        AND T.MeterNumber = S.MeterNumber

                        WHEN MATCHED THEN
                        UPDATE SET
                            T.TestResultCode       = S.TestResultCode,
                            T.CorrectiveActionCode = S.CorrectiveActionCode,
                            T.ISSync = 1

                        WHEN NOT MATCHED THEN
                        INSERT (
                            MaintenanceRecordCode,
                            MeterNumber,
                            TestResultCode,
                            CorrectiveActionCode,
                            ISSync
                        )
                        VALUES (
                            S.MaintenanceRecordCode,
                            S.MeterNumber,
                            S.TestResultCode,
                            S.CorrectiveActionCode,
                            1
                        );";

                            await cmd.ExecuteNonQueryAsync();
                        }

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        // =====================================================
        // LOAD HEADER + DETAILS
        // =====================================================
        public async Task<MeterMaintenanceFullLocalDto> GetByCodeAsync(long code)
        {
            string headerSql = @"
            SELECT *
            FROM MaintenanceRecord
            WHERE MaintenanceRecordCode = @code";

            string detailSql = @"
            SELECT *
            FROM MaintenanceRecord_Detail
            WHERE MaintenanceRecordCode = @code";

            var header = await _db.QueryFirstOrDefaultAsync<MeterMaintenanceLocal>(
                headerSql,
                new { code });

            var details = (await _db.QueryAsync<MaintenanceRecordDetailLocal>(
                detailSql,
                new { code = code.ToString() }))
                .ToList();

            return new MeterMaintenanceFullLocalDto
            {
                Header = header,
                Details = details
            };
        }

        // =====================================================
        // DELETE HEADER + DETAILS
        // =====================================================
        public async Task DeleteAsync(long code)
        {
            if (_db.State != ConnectionState.Open)
                _db.Open();

            using (var tran = _db.BeginTransaction())
            {
                try
                {
                    await _db.ExecuteAsync(
                        "DELETE FROM MaintenanceRecord_Detail WHERE MaintenanceRecordCode = @code",
                        new { code = code.ToString() },
                        tran);

                    await _db.ExecuteAsync(
                        "DELETE FROM MaintenanceRecord WHERE MaintenanceRecordCode = @code",
                        new { code },
                        tran);

                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        // =====================================================
        // UPDATE HEADER + DETAILS
        // =====================================================
        public async Task UpdateAsync(MeterMaintenanceFullLocalDto model)
        {
            if (_db.State != ConnectionState.Open)
                _db.Open();

            using (var tran = _db.BeginTransaction())
            {
                try
                {
                    model.Header.UserId = SystemInfo.userId;
                    model.Header.ISSync = false;

                    // ---------- UPDATE HEADER ----------
                    string headerSql = @"
                    UPDATE MaintenanceRecord
                    SET
                        MaintenanceRecordDate = @MaintenanceRecordDate,
                        CompanySectorDept_Id = @CompanySectorDept_Id,
                        LabCenter_Id = @LabCenter_Id,
                        MeterCount = @MeterCount,
                        WorkingMetersCount = @WorkingMetersCount,
                        RepairedMetersCount = @RepairedMetersCount,
                        RetiredMetersCount = @RetiredMetersCount,
                        ISSync = @ISSync,
                        CompanySectorDept_Level = @CompanySectorDept_Level,
                        UserId = @UserId
                    WHERE MaintenanceRecordCode = @MaintenanceRecordCode;";

                            await _db.ExecuteAsync(headerSql, model.Header, tran);

                            // ---------- DELETE OLD DETAILS ----------
                            await _db.ExecuteAsync(
                                @"DELETE FROM MaintenanceRecord_Detail 
                          WHERE MaintenanceRecordCode = @code",
                                new { code = model.Header.MaintenanceRecordCode.ToString() },
                                tran);

                            // ---------- INSERT NEW DETAILS ----------
                            string detailSql = @"
                    INSERT INTO MaintenanceRecord_Detail
                    (
                        MaintenanceRecordCode,
                        MeterNumber,
                        TestResultCode,
                        CorrectiveActionCode,
                        ISSync
                    )
                    VALUES
                    (
                        @MaintenanceRecordCode,
                        @MeterNumber,
                        @TestResultCode,
                        @CorrectiveActionCode,
                        @ISSync
                    );";

                    foreach (var d in model.Details)
                    {
                        d.MaintenanceRecordCode =
                            model.Header.MaintenanceRecordCode.ToString();

                        d.ISSync = false;

                        await _db.ExecuteAsync(detailSql, d, tran);
                    }

                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

    }

}

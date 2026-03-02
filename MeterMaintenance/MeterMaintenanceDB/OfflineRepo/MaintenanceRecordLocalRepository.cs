using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MeterMaintenanceDB.Model;
using MeterMaintenanceDB.OfflineModel;

namespace MeterMaintenanceDB.OfflineRepo
{

    public class MaintenanceRecordLocalRepository
    {
        private readonly IDbConnection _db;
        public MaintenanceRecordLocalRepository(IDbConnection db) 
        {
            _db = db;
        }
        // Get all records
        public async Task<IEnumerable<MeterMaintenanceLocal>> GetAllAsync()
        {
            string sql = @"SELECT TOP (1000) [Id],
                                  [MaintenanceRecordDate],
                                  [CompanySectorDept_Id],
                                  [LabCenter_Id],
                                  [MeterCount],
                                  [WorkingMetersCount],
                                  [RepairedMetersCount],
                                  [RetiredMetersCount],
                                  [MaintenanceRecordCode],
                                  [ISSync],
                                  [CompanySectorDept_Level]
                           FROM [dbo].[MaintenanceRecord]";
            return await _db.QueryAsync<MeterMaintenanceLocal>(sql);
        }

        // Get record by Id
        public async Task<MeterMaintenanceLocal> GetByIdAsync(int id)
        {
            string sql = @"SELECT [Id],
                                  [MaintenanceRecordDate],
                                  [CompanySectorDept_Id],
                                  [LabCenter_Id],
                                  [MeterCount],
                                  [WorkingMetersCount],
                                  [RepairedMetersCount],
                                  [RetiredMetersCount],
                                  [MaintenanceRecordCode],
                                  [ISSync],
                                  [CompanySectorDept_Level]
                           FROM [dbo].[MaintenanceRecord]
                           WHERE Id = @Id";
            return await _db.QueryFirstOrDefaultAsync<MeterMaintenanceLocal>(sql, new { Id = id });
        }

        // Insert a new record
        public async Task<int> AddAsync(MeterMaintenanceLocal record)
        {
            record.MaintenanceRecordCode =
                long.Parse(DateTime.Now.ToString("yyyyMMddHHmmssfff") + SystemInfo.userId.ToString())
            ;
            string sql = @"INSERT INTO [dbo].[MaintenanceRecord] 
                            ([MaintenanceRecordDate], [CompanySectorDept_Id], [LabCenter_Id], [MeterCount],
                             [WorkingMetersCount], [RepairedMetersCount], [RetiredMetersCount],
                             [MaintenanceRecordCode], [ISSync], [CompanySectorDept_Level])
                           VALUES
                            (@MaintenanceRecordDate, @CompanySectorDept_Id, @LabCenter_Id, @MeterCount,
                             @WorkingMetersCount, @RepairedMetersCount, @RetiredMetersCount,
                             @MaintenanceRecordCode, @ISSync, @CompanySectorDept_Level);
                           SELECT CAST(SCOPE_IDENTITY() as int);";
            return await _db.ExecuteScalarAsync<int>(sql, record);
        }

        // Update a record
        public async Task<bool> UpdateAsync(MeterMaintenanceLocal record)
        {
            string sql = @"UPDATE [dbo].[MaintenanceRecord]
                           SET MaintenanceRecordDate = @MaintenanceRecordDate,
                               CompanySectorDept_Id = @CompanySectorDept_Id,
                               LabCenter_Id = @LabCenter_Id,
                               MeterCount = @MeterCount,
                               WorkingMetersCount = @WorkingMetersCount,
                               RepairedMetersCount = @RepairedMetersCount,
                               RetiredMetersCount = @RetiredMetersCount,
                               MaintenanceRecordCode = @MaintenanceRecordCode,
                               ISSync = @ISSync,
                               CompanySectorDept_Level = @CompanySectorDept_Level
                           WHERE Id = @Id";
            int rows = await _db.ExecuteAsync(sql, record);
            return rows > 0;
        }

        // Delete a record
        public async Task<bool> DeleteAsync(int id)
        {
            string sql = @"DELETE FROM [dbo].[MaintenanceRecord] WHERE Id = @Id";
            int rows = await _db.ExecuteAsync(sql, new { Id = id });
            return rows > 0;
        }
    }
}

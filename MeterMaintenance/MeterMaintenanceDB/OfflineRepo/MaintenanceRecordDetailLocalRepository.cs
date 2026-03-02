using Dapper;
using MeterMaintenanceDB.OfflineModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterMaintenanceDB.OfflineRepo
{
    public class MaintenanceRecordDetailLocalRepository
    {
        private readonly IDbConnection _db;

        public MaintenanceRecordDetailLocalRepository(IDbConnection db)
        {
            _db = db;
        }

        // Get top 1000 records
        public async Task<IEnumerable<MaintenanceRecordDetailLocal>> GetAllAsync()
        {
            string sql = @"SELECT TOP (1000) [Id],
                                  [MaintenanceRecordCode],
                                  [MeterNumber],
                                  [TestResultCode],
                                  [CorrectiveActionCode],
                                  [ISSync]
                           FROM [MeterMaintenance_LocalDB].[dbo].[MaintenanceRecord_Detail]";
            return await _db.QueryAsync<MaintenanceRecordDetailLocal>(sql);
        }

        // Get record by Id
        public async Task<MaintenanceRecordDetailLocal> GetByIdAsync(int id)
        {
            string sql = @"SELECT [Id],
                                  [MaintenanceRecordCode],
                                  [MeterNumber],
                                  [TestResultCode],
                                  [CorrectiveActionCode],
                                  [ISSync]
                           FROM [MeterMaintenance_LocalDB].[dbo].[MaintenanceRecord_Detail]
                           WHERE Id = @Id";
            return await _db.QueryFirstOrDefaultAsync<MaintenanceRecordDetailLocal>(sql, new { Id = id });
        }

        // Insert a new record
        public async Task<int> AddAsync(MaintenanceRecordDetailLocal record)
        {
            string sql = @"INSERT INTO [MeterMaintenance_LocalDB].[dbo].[MaintenanceRecord_Detail] 
                            ([MaintenanceRecordCode], [MeterNumber], [TestResultCode], [CorrectiveActionCode], [ISSync])
                           VALUES
                            (@MaintenanceRecordCode, @MeterNumber, @TestResultCode, @CorrectiveActionCode, @ISSync);
                           SELECT CAST(SCOPE_IDENTITY() as int);";
            return await _db.ExecuteScalarAsync<int>(sql, record);
        }

        // Update a record
        public async Task<bool> UpdateAsync(MaintenanceRecordDetailLocal record)
        {
            string sql = @"UPDATE [MeterMaintenance_LocalDB].[dbo].[MaintenanceRecord_Detail]
                           SET MaintenanceRecordCode = @MaintenanceRecordCode,
                               MeterNumber = @MeterNumber,
                               TestResultCode = @TestResultCode,
                               CorrectiveActionCode = @CorrectiveActionCode,
                               ISSync = @ISSync
                           WHERE Id = @Id";
            int rows = await _db.ExecuteAsync(sql, record);
            return rows > 0;
        }

        // Delete a record
        public async Task<bool> DeleteAsync(int id)
        {
            string sql = @"DELETE FROM [MeterMaintenance_LocalDB].[dbo].[MaintenanceRecord_Detail] WHERE Id = @Id";
            int rows = await _db.ExecuteAsync(sql, new { Id = id });
            return rows > 0;
        }
    }
}

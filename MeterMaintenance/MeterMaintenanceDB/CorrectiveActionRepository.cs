using Dapper;
using MeterMaintenanceDB.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterMaintenanceDB
{
    public class CorrectiveActionRepository
    {
        private readonly IDbConnection _db;

        public CorrectiveActionRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<CorrectiveAction>> GetAllAsync()
        {
            string sql = @"SELECT * FROM [MeterMaintenance_LocalDB].[dbo].[CorrectiveAction]";
            return await _db.QueryAsync<CorrectiveAction>(sql);
        }


        public async Task<CorrectiveAction> GetByIdAsync(int id)
        {
            string sql = @"SELECT * FROM [MeterMaintenance_LocalDB].[dbo].[CorrectiveAction]
                           WHERE Id = @Id";

            return await _db.QueryFirstOrDefaultAsync<CorrectiveAction>(sql, new { Id = id });
        }


        public async Task<int> AddAsync(CorrectiveAction action)
        {
            string sql = @"
                INSERT INTO [MeterMaintenance_LocalDB].[dbo].[CorrectiveAction]
                (CorrectiveActionCode, CorrectiveActionName)
                VALUES (@CorrectiveActionCode, @CorrectiveActionName);

                SELECT CAST(SCOPE_IDENTITY() as int);";

            return await _db.ExecuteScalarAsync<int>(sql, action);
        }


        public async Task<bool> UpdateAsync(CorrectiveAction action)
        {
            string sql = @"
                UPDATE [MeterMaintenance_LocalDB].[dbo].[CorrectiveAction]
                SET CorrectiveActionCode = @CorrectiveActionCode,
                    CorrectiveActionName = @CorrectiveActionName
                WHERE Id = @Id";

            return await _db.ExecuteAsync(sql, action) > 0;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            string sql = @"DELETE FROM [MeterMaintenance_LocalDB].[dbo].[CorrectiveAction]
                           WHERE Id = @Id";

            return await _db.ExecuteAsync(sql, new { Id = id }) > 0;
        }
    }
}

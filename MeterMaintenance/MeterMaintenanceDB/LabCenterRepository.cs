using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MeterMaintenanceDB.Model;

namespace MeterMaintenanceDB
{
    public class LabCenterRepository
    {
      
            private readonly IDbConnection _db;

            public LabCenterRepository(IDbConnection db)
            {
                _db = db;
            }

            public async Task<IEnumerable<LabCenter>> GetAllAsync()
            {
                string sql = @"SELECT * FROM [dbo].[LabCenter]";
                var data = await _db.QueryAsync<LabCenter>(sql);
                return data.ToList();
            }

            public async Task<LabCenter> GetByIdAsync(int id)
            {
                string sql = @"SELECT * FROM [dbo].[LabCenter]
                           WHERE Id = @Id";

                return await _db.QueryFirstOrDefaultAsync<LabCenter>(sql, new { Id = id });
            }

            public async Task<int> AddAsync(LabCenter labCenter)
            {
                string sql = @"
                INSERT INTO [dbo].[LabCenter] (LabCenterName)
                VALUES (@LabCenterName);

                SELECT CAST(SCOPE_IDENTITY() as int);";

                return await _db.ExecuteScalarAsync<int>(sql, labCenter);
            }

            public async Task<bool> UpdateAsync(LabCenter labCenter)
            {
                string sql = @"
                UPDATE [dbo].[LabCenter]
                SET LabCenterName = @LabCenterName
                WHERE Id = @Id";

                return await _db.ExecuteAsync(sql, labCenter) > 0;
            }

            public async Task<bool> DeleteAsync(int id)
            {
                string sql = @"DELETE FROM [dbo].[LabCenter]
                           WHERE Id = @Id";

                return await _db.ExecuteAsync(sql, new { Id = id }) > 0;
            }
        

    }
}

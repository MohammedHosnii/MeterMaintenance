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
    public class UserRepository
    {
        private readonly IDbConnection _db;

        public UserRepository(IDbConnection db)
        {
            _db = db;
        }

        // Get all users
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            string sql = @"SELECT * FROM [dbo].[Users]";
            return await _db.QueryAsync<User>(sql);
        }

        // Get user by Id
        public async Task<User> GetByIdAsync(int id)
        {
            string sql = @"SELECT * FROM [dbo].[Users] WHERE Id = @Id";
            return await _db.QueryFirstOrDefaultAsync<User>(sql, new { Id = id });
        }

        public async Task<User> GetByCodeAsync(string UserCode)
        {
            string sql = @"SELECT * FROM [dbo].[Users] WHERE UserCode = @UserCode";
            return await _db.QueryFirstOrDefaultAsync<User>(sql, new { UserCode = UserCode });
        }

        // Add new user
        public async Task<int> AddAsync(User user)
        {
            string sql = @"
                INSERT INTO [dbo].[Users] 
                (UserCode, UserName, UserPassword, UserDegree)
                VALUES 
                (@UserCode, @UserName, @UserPassword, @UserDegree);

                SELECT CAST(SCOPE_IDENTITY() as int);";

            return await _db.ExecuteScalarAsync<int>(sql, user);
        }

        // Update user
        public async Task<bool> UpdateAsync(User user)
        {
            string sql = @"
                UPDATE [dbo].[Users]
                SET UserCode = @UserCode,
                    UserName = @UserName,
                    UserPassword = @UserPassword,
                    UserDegree = @UserDegree
                WHERE Id = @Id";

            return await _db.ExecuteAsync(sql, user) > 0;
        }

        // Delete user
        public async Task<bool> DeleteAsync(int id)
        {
            string sql = @"DELETE FROM [dbo].[Users] WHERE Id = @Id";
            return await _db.ExecuteAsync(sql, new { Id = id }) > 0;
        }
    }
}

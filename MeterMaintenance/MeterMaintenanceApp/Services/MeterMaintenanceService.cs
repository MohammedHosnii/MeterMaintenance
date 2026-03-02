using MeterMaintenanceDB.OfflineModel;
using MeterMaintenanceDB.OfflineRepo;
using MeterMaintenanceDB;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MeterMaintenanceApp.Services
{

    public class MeterMaintenanceLocalService : IDisposable
    {
        private readonly SystemInfo _systemInfo;
        private SqlConnection _connection;

        private MeterMaintenanceFullLocalRepository _repo;

        public MeterMaintenanceLocalService()
        {
            _systemInfo = new SystemInfo();
        }

        // ============================================
        // Initialize connection + repositories
        // ============================================
        public async Task<bool> InitializeAsync()
        {
            await _systemInfo.GetActiveConnectionAsync();
            if(_systemInfo.IsOnline)
            {
                if (string.IsNullOrEmpty(_systemInfo.ConnectionStr_Server))
                    throw new InvalidOperationException("Local connection not initialized.");

                _connection = new SqlConnection(_systemInfo.ConnectionStr_Server);
                await _connection.OpenAsync();

                _repo = new MeterMaintenanceFullLocalRepository(_connection);

                return _systemInfo.IsOnline;
            }
            if (string.IsNullOrEmpty(_systemInfo.ConnectionStr_Local))
                throw new InvalidOperationException("Local connection not initialized.");

            _connection = new SqlConnection(_systemInfo.ConnectionStr_Local);
            await _connection.OpenAsync();

            _repo = new MeterMaintenanceFullLocalRepository(_connection);

            return _systemInfo.IsOnline;
        }

        // ============================================
        // INSERT
        // ============================================
        public async Task SaveAsync(MeterMaintenanceFullLocalDto dto)
        {
            await _repo.SaveAsync(dto);
        }

        public async Task  SyncFromServerToLocal(MeterMaintenanceFullLocalDto dto)
        {
            await _repo.SyncFromServerToLocal(dto);
        }

        // ============================================
        // LOAD
        // ============================================
        public async Task<MeterMaintenanceFullLocalDto> GetAsync(long code)
        {
            return await _repo.GetByCodeAsync(code);
        }

        // ============================================
        // DELETE
        // ============================================
        public async Task DeleteAsync(long code)
        {
            await _repo.DeleteAsync(code);
        }

        // ============================================
        // UPDATE  
        // ============================================
        public async Task UpdateAsync(MeterMaintenanceFullLocalDto dto)
        {
            await _repo.UpdateAsync(dto);
        }

        // ============================================
        // Connection helper
        // ============================================
        public string GetConnectionString()
        {
            return _systemInfo.ConnectionStr_Local;
        }

        // ============================================
        // Dispose
        // ============================================
        public void Dispose()
        {
            _connection?.Dispose();
        }
    }

}

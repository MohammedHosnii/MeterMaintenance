using MeterMaintenanceDB.Model;
using MeterMaintenanceDB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using MeterMaintenanceDB.OfflineRepo;


namespace MeterMaintenanceApp.Services
{
    
    namespace MeterMaintenanceApp.Services
    {
        public class MaintenanceRecordViewService : IDisposable
        {
            private readonly SystemInfo _systemInfo;
            private SqlConnection _connection;

            private MaintenanceRecordViewRepository _repo;

            public MaintenanceRecordViewService()
            {
                _systemInfo = new SystemInfo();
            }

        
            public async Task<bool> InitializeAsync()
            {
                await _systemInfo.GetActiveConnectionAsync();

                if (_systemInfo.IsOnline)
                {
                    if (string.IsNullOrEmpty(_systemInfo.ConnectionStr_Server))
                        throw new InvalidOperationException("Local connection not initialized.");

                    _connection = new SqlConnection(_systemInfo.ConnectionStr_Server);
                    await _connection.OpenAsync();

                    _repo = new MaintenanceRecordViewRepository(_connection);


                    return _systemInfo.IsOnline;
                }

                if (string.IsNullOrEmpty(_systemInfo.ConnectionStr_Local))
                    throw new InvalidOperationException("Local connection not initialized.");

                _connection = new SqlConnection(_systemInfo.ConnectionStr_Local);
                await _connection.OpenAsync();

                _repo = new MaintenanceRecordViewRepository(_connection);

                return _systemInfo.IsOnline;
            }

           
            public async Task<IEnumerable<MaintenanceRecordView>> GetAllAsync()
            {
                return await _repo.GetAllAsync();
            }

            // ============================================
            // GET FILTERED
            // ============================================
            public async Task<IEnumerable<MaintenanceRecordView>>
                GetByDepartmentAsync(int deptId)
            {
                return await _repo.GetByDepartmentAsync(deptId);
            }

            public async Task<IEnumerable<MaintenanceRecordView>>
               GetByWhereAsync(string whereStr)
            {
                return await _repo.GetByWhereAsync(whereStr);
            }



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

}

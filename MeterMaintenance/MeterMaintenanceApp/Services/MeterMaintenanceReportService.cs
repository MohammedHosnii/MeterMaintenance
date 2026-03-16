
using MeterMaintenanceDB;
using MeterMaintenanceDB.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MeterMaintenanceApp.Services
{
    public class MeterMaintenanceReportService : IDisposable
    {
        private readonly SystemInfo _systemInfo;
        private SqlConnection _connection;
        private MeterMaintenanceReportRepository _repo;

        public MeterMaintenanceReportService()
        {
            _systemInfo = new SystemInfo();
        }

        public async Task<bool> InitializeAsync()
        {
            await _systemInfo.GetActiveConnectionAsync();

            if (_systemInfo.IsOnline)
            {
                if (string.IsNullOrEmpty(_systemInfo.ConnectionStr_Server))
                    throw new InvalidOperationException("Server connection not initialized.");

                _connection = new SqlConnection(_systemInfo.ConnectionStr_Server);
                await _connection.OpenAsync();

                _repo = new MeterMaintenanceReportRepository(_connection);

                return _systemInfo.IsOnline;
            }

            if (string.IsNullOrEmpty(_systemInfo.ConnectionStr_Local))
                throw new InvalidOperationException("Local connection not initialized.");

            _connection = new SqlConnection(_systemInfo.ConnectionStr_Local);
            await _connection.OpenAsync();

            _repo = new MeterMaintenanceReportRepository(_connection);

            return _systemInfo.IsOnline;
        }

        // ============================================
        // GET REPORT
        // ============================================
        public async Task<IEnumerable<MeterMaintenanceReport>>
            GetReportAsync(long maintenanceRecordCode)
        {
            return await _repo.GetReportAsync(maintenanceRecordCode);
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

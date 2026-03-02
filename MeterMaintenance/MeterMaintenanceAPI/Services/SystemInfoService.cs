using MeterMaintenanceDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MeterMaintenanceAPI.Services
{
    public class SystemInfoService
    {
        private readonly SystemInfo _systemInfo;

        public SystemInfoService()
        {
            _systemInfo = new SystemInfo();
        }

        public async Task<bool> InitializeAsync()
        {
            await _systemInfo.GetActiveConnectionAsync();

            if (_systemInfo.Connection_Local != null)
                _systemInfo.CollectSystemInfo();

            return _systemInfo.IsOnline;
        }

        public int GetUnSyncedCount()
        {
            return _systemInfo.GetUnSyncedRecordCount();
        }

        public object GetSystemSnapshot()
        {
            return new
            {
                _systemInfo.userCode,
                _systemInfo.userName,
                _systemInfo.MaxUnSyncedCount,
                _systemInfo.IsOnline
            };
        }
    }

}
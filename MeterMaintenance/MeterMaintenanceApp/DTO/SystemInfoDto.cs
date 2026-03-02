using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterMaintenanceApp.DTO
{
    public class SystemInfoDto
    {
        public string UserName { get; set; }
        public int MaxUnSyncedCount { get; set; }
        public bool IsOnline { get; set; }
    }

}

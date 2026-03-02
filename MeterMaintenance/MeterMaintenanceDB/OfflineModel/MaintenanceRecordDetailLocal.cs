using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterMaintenanceDB.OfflineModel
{
    public class MaintenanceRecordDetailLocal
    {
        public int Id { get; set; }
        public string MaintenanceRecordCode { get; set; }
        public string MeterNumber { get; set; }
        public string TestResultCode { get; set; }
        public string CorrectiveActionCode { get; set; }
        public bool ISSync { get; set; }
    }
}

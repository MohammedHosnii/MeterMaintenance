using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterMaintenanceDB.Model
{
    public class MeterMaintenanceReport
    {
        public DateTime MaintenanceRecordDate { get; set; }
        public string CompanySectorDept { get; set; }
        public string LabCenter { get; set; }
        public int MeterCount { get; set; }
        public int WorkingMetersCount { get; set; }
        public int RepairedMetersCount { get; set; }
        public int RetiredMetersCount { get; set; }
        public long MaintenanceRecordCode { get; set; }
        public bool ISSync { get; set; }
        public int CompanySectorDept_Level { get; set; }
        public string User { get; set; }

        public string MeterNumber { get; set; }
        public string TestResult { get; set; }
        public string CorrectiveAction { get; set; }

        public string CompanyName { get; set; }
    }
}

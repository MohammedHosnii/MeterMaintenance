using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterMaintenanceDB.Model
{
    public class MaintenanceRecordView
    {
        public DateTime MaintenanceRecordDate { get; set; }

        public string CompanySectorDeptName { get; set; }

        public int MeterCount { get; set; }

        public int WorkingMetersCount { get; set; }

        public int RepairedMetersCount { get; set; }

        public int RetiredMetersCount { get; set; }

        public string MaintenanceRecordCode { get; set; }

        public bool ISSync { get; set; }

        public string CompanySectorDept_Level { get; set; }

        public string LabCenterName { get; set; }
    }

}

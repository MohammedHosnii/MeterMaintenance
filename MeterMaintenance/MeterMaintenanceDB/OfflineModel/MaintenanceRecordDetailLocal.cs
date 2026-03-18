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

        public long MaintenanceRecordCode { get; set; }

        public long MeterNumber { get; set; }

        public int TestResultCode { get; set; }

        public int CorrectiveActionCode { get; set; }

        public int ErrorNumber { get; set; }

        public DateTime CreationDateTime { get; set; }

        public string Notes { get; set; }

        public DateTime? ModificationDateTime { get; set; }

        public bool ISSync { get; set; }
    }
}

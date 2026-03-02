using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterMaintenanceDB.OfflineModel
{
    public class MeterMaintenanceFullLocalDto
    {
        public MeterMaintenanceLocal Header { get; set; }

        public List<MaintenanceRecordDetailLocal> Details { get; set; }
    }

}

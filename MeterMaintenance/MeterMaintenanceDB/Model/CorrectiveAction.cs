using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterMaintenanceDB.Model
{
    public class CorrectiveAction
    {
        public int Id { get; set; }
        public string CorrectiveActionCode { get; set; }
        public string CorrectiveActionName { get; set; }
    }
}

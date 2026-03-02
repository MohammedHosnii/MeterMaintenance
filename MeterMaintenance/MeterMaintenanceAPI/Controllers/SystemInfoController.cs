using MeterMaintenanceAPI.Services;
using System.Threading.Tasks;
using System.Web.Http;

namespace MeterMaintenanceAPI.Controllers
{

    [RoutePrefix("api/system")]
    public class SystemInfoController : ApiController
    {
        private readonly SystemInfoService _service;

        public SystemInfoController()
        {
            _service = new SystemInfoService();
        }

        // 🔹 Initialize connections
        [HttpGet]
        [Route("init")]
        public async Task<IHttpActionResult> Initialize()
        {
            
            var online = await _service.InitializeAsync();

            return Ok(new
            {
                IsOnline = online
            });
        }

        // 🔹 Get system info snapshot
        [HttpGet]
        [Route("info")]
        public IHttpActionResult GetSystemInfo()
        {
            var data = _service.GetSystemSnapshot();
            return Ok(data);
        }

        // 🔹 Unsynced records count
        [HttpGet]
        [Route("unsynced")]
        public IHttpActionResult GetUnsynced()
        {
            var count = _service.GetUnSyncedCount();
            return Ok(count);
        }
    }

}

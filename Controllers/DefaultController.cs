using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaeri.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    [Route("/")]
    public class DefaultController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            //var netCoreVer = System.Environment.Version; // 3.0.0
            var runtimeVer = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription; // .NET Core 3.0.0-preview4.19113.15

            return StatusCode(418, "The public temporal API running with " + runtimeVer);
        }
    }
}

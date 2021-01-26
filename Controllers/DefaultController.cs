using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Kaeri.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    [Route("/")]
    public class DefaultController : ControllerBase
    {

        [HttpGet]
        public ContentResult Get()
        {
            //var netCoreVer = System.Environment.Version; // 3.0.0
            var runtimeVer = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription; // .NET Core 3.0.0-preview4.19113.15

            //return StatusCode(418, "The public temporal API running with " + runtimeVer);

            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = 418,
                Content = $"<html><body>Welcome to Kaori Endpoint, working under {runtimeVer}</body></html>" +
                "<br>" +
                "<a href=\"/swagger\">API Doc</a>" +
                "<br>" +
                "<a href=\"https://github.com/aeri/Kaeri\">GitHub Repository</a>"
            };
        }

    }
}
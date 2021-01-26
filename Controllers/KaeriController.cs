using Kaeri.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kaeri.Controllers
{
    [Route("api")]
    [ApiController]
    public class KaeriController : ControllerBase
    {

        //Dictionary<int, string> data = new Dictionary<int, string>();
        private static readonly List<KaeriObjectDto> data = new List<KaeriObjectDto>();

        // GET: api/
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<KaeriObjectDto>> Get()
        {
            return data;
        }

        // GET api/5
        [HttpGet("{key}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KaeriObjectDto> Get(string key)
        {
            var kobject = data.Find(x => x.Key.Equals(key));

            if (kobject == null)
            {
                return Problem($"The key {key} does not exist", statusCode: (int)HttpStatusCode.NotFound);
            }

            return kobject;

        }

        // POST api/
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult<KaeriObjectDto> Post(KaeriObject newObject)
        {

            var kobject = data.Find(x => x.Key.Equals(newObject.Key));

            if (kobject != null)
            {
                return Problem($"The key {kobject.Key} already exists", statusCode: (int)HttpStatusCode.Conflict);
            }

            data.Add(new KaeriObjectDto
            {
                Key = newObject.Key,
                Value = newObject.Value,
                Created = DateTime.UtcNow
            });

            return CreatedAtAction(nameof(Get), new { newObject.Key }, newObject);


            //var remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress;


        }

        // PUT api/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{key}")]
        public IActionResult Put(string key, KaeriObject kobject)
        {
            if (key != kobject.Key)
            {
                return Problem($"The provided keys {kobject.Key} does not match", statusCode: (int)HttpStatusCode.BadRequest);
            }

            //_context.Entry(todoItem).State = EntityState.Modified;

            var traceId = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;

            //Console.WriteLine(traceId);

            var index = data.FindIndex(x => x.Key.Equals(key));

            //Console.WriteLine(index);

            if (index < 0)
            {
                data.Add(new KaeriObjectDto
                {
                    Key = kobject.Key,
                    Value = kobject.Value,
                    Created = DateTime.UtcNow
                });

                return CreatedAtAction(nameof(Get), new { kobject.Key }, kobject);
            }
            else
            {
                data[index].Value = kobject.Value;
            }

            return NoContent();
        }


        // DELETE api/5
        [HttpDelete("{key}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(string key)
        {

            var kobject = data.Find(x => x.Key.Equals(key));

            if (kobject == null)
            {
                return Problem($"The key {key} does not exist", statusCode: (int)HttpStatusCode.NotFound);
            }

            data.Remove(kobject);

            return NoContent();
        }

    }
}

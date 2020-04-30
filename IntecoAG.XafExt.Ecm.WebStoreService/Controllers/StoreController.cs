using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntecoAG.XafExt.Ecm.WebStoreService.Logic;
using IntecoAG.XafExt.Ecm.WebStoreService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestAPI.Models;

namespace IntecoAG.XafExt.Ecm.WebStoreService.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class StoreController : ControllerBase
    {
        public StoreController(ILogger<StoreController> logger)
        {
            _logger = logger;
        }
        private readonly ILogger<StoreController> _logger;
        [HttpPost]
        [Route("{post}")]
        public async Task<ActionResult> Post()
        {
            Document doc = new Document();
            doc.Name = Guid.NewGuid().ToString();
            Response.StatusCode = 201;
            Response.ContentType = "application/json";
            Response.Body = new MemoryStream(Encoding.UTF8.GetBytes(doc.Name));
            return Ok();
        }

        [HttpPost("id")]
        [Route("{post}/{id}")]
        public async Task<ActionResult> Post(String id)
        {
            Document doc = new Document();
            doc.Name = id;
            Response.StatusCode = 201;
            Response.ContentType = "application/json";
            Response.Body = new MemoryStream(Encoding.UTF8.GetBytes(doc.Name));
            return Ok();
        }
        
        [HttpGet("{id}")]
        [Route("{get}/{id}")]
        public async Task<ActionResult> Get(String id)
        {
            if (String.IsNullOrEmpty(id)) return new NoContentResult();
            var path = StoreLogic.GetFullName($"{id}.pdf");
            if (System.IO.File.Exists(path))
            {
                //ViewBag.Path = path;
                FileStream stream = null;
                try
                {

                    stream = new FileStream(path, FileMode.Open);
                    return new FileStreamResult(stream, "application/pdf");
                }
                catch (Exception e)
                {
                    stream?.Dispose();
                }
            }
            return new NoContentResult();
        }

        [HttpPut("{id}")]
        [Route("{put}/{id}")]
        public async Task<ActionResult> Put(String id)
        {
            var path = StoreLogic.GetFullName($"{id}.pdf");
            if (System.IO.File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(Request.Body))
                {
                    var text = reader.ReadToEnd();
                    using (StreamWriter writer = new StreamWriter(path))
                    {
                        writer.Write(text);
                    }
                }
                return Ok();
            }
            return new BadRequestResult();
            
        }
    }
}
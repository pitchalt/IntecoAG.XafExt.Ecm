using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntecoAG.XafExt.Ecm.WebStoreService.Logic;
using IntecoAG.XafExt.Ecm.WebStoreService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestAPI.Models;
using System.IO;

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
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DocDTO>> Post(DocDTO document)
        {
            if (document is null)
            {
                return BadRequest();
            }

            var r = new DocDTO() {Id = Guid.NewGuid()};
          var uri=  this.Url.RouteUrl(this.RouteData);

            return Created(uri,r);
            //Document doc = new Document();
            //doc.Name = Guid.NewGuid().ToString();
            //Response.StatusCode = 201;
            //Response.ContentType = "application/json";
            //Response.Body = new MemoryStream(Encoding.UTF8.GetBytes(doc.Name));
            //return Ok();
        }

        [HttpPost]
        [Route("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult> Post(Guid id, DocDTO document)
        {
            //Принимает минимальное количество парметров в документе, колдует и позвращает докуменент

            //Document doc = new Document();
            //doc.Name = id;
            //Response.StatusCode = 201;
            //Response.ContentType = "application/json";
            //Response.Body = new MemoryStream(Encoding.UTF8.GetBytes(doc.Name));
            return Ok();
        }
        
        [HttpGet]
        [Route("{id}/content")]
        [Produces("application/json")]
        public async Task<ActionResult<DocDTO>> GetContent(Guid id)
        {
            //Возращает либо пдф, либо ошибку
            return Ok();
            //if (String.IsNullOrEmpty(id)) return new NoContentResult();
            //var path = StoreLogic.GetFullName($"{id}.pdf");
            //if (System.IO.File.Exists(path))
            //{
            //    //ViewBag.Path = path;
            //    FileStream stream = null;
            //    try
            //    {

            //        stream = new FileStream(path, FileMode.Open);
            //        return new FileStreamResult(stream, "application/pdf");
            //    }
            //    catch (Exception e)
            //    {
            //        stream?.Dispose();
            //    }
            //}
            //return new NoContentResult();
        }

        [HttpGet]
        [Route("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<DocDTO>> GetDocument(Guid id)
        {

            return Ok();
        }

        [HttpPut]
        [Route("{id}/content")]
        [Produces("application/pdf")]
        public async Task<ActionResult> Put(Guid id)
        {
            //метод найдет хранимый документ и привяжет к нему содержимое. вернёт ОК или ошибку
            return Ok();
            //var path = StoreLogic.GetFullName($"{id}.pdf");
            //if (System.IO.File.Exists(path))
            //{
            //    using(FileStream stream = System.IO.File.Open(path, System.IO.FileMode.Open){
            //        await Request.Body.CopyToAsync(stream);
            //    }
            //}
            //return new BadRequestResult();
        }
    }
}
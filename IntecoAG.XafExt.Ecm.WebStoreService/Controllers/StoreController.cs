using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using IntecoAG.XafExt.Ecm.WebStoreService.Logic;
using IntecoAG.XafExt.Ecm.WebStoreService.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestAPI.Models;
using System.IO;
using DevExpress.ExpressApp;

namespace IntecoAG.XafExt.Ecm.WebStoreService.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class StoreController : ControllerBase
    {
        public readonly IObjectSpace ObjectSpace;
        public StoreController(ILogger<StoreController> logger, IObjectSpace objectSpace)
        {
            ObjectSpace = objectSpace;
            _logger = logger;
        }
        private readonly ILogger<StoreController> _logger;
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(DocDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ServerErrorDTO))]
        public async Task<ActionResult> Post(DocDTO document)
        {
            if (document is null)
            {
                return BadRequest();
            }
            //document.Id = Guid.NewGuid();
            var doc = ObjectSpace.CreateObject<EcmDocument>();
            doc.ObjectId = Guid.NewGuid().ToString();
            var uri = this.Url.RouteUrl(this.RouteData);

            return Created(uri, doc);
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DocDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ServerErrorDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestDTO))]
        public async Task<ActionResult> Post(Guid id, DocDTO document)
        {
            //Принимает минимальное количество парметров в документе, колдует и позвращает докуменент

            //Document doc = new Document();
            //doc.Name = id;
            //Response.StatusCode = 201;
            //Response.ContentType = "application/json";
            //Response.Body = new MemoryStream(Encoding.UTF8.GetBytes(doc.Name));
            if(document is null)
            {
                return BadRequest();
            }
            var doc = ObjectSpace.CreateObject<EcmDocument>();
            doc.ObjectId = id.ToString();
            var uri = this.Url.RouteUrl(this.RouteData);
            return Created(uri, doc);
            //return Ok();
        }

      
        [HttpGet]
        [Route("{id}/content")]
  
        [Produces("application/pdf", "application/json")]
     
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ServerErrorDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestDTO))]
        public async Task<ActionResult> GetContent(Guid id)
        {
            //Возращает либо пдф, либо ошибку
            //return Ok();
            //if (String.IsNullOrEmpty(id)) return new NoContentResult();
            var path = StoreLogic.GetFullName($"{id}.pdf");
            if (System.IO.File.Exists(path))
            {
                FileStream stream = null;
                stream = new FileStream(path, FileMode.Open);
                return new FileStreamResult(stream, "application/pdf");
            }

            return NotFound();
        }

        [HttpGet]
        [Route("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ServerErrorDTO))]

        public async Task<ActionResult> GetDocument(Guid id)
        {
            //var path = StoreLogic.GetFullName($"{id}.pdf");
            //if (!System.IO.File.Exists(path))
            //{
            //    return new NotFoundResult();
            //}
            //var doc = ObjectSpace.GetObjectByKey<EcmDocument>(id);
            var doc = ObjectSpace.CreateObject<EcmDocument>();
            doc.ObjectId = Guid.NewGuid().ToString();
            var json = JsonSerializer.Serialize<EcmDocument>(doc);
            await Response.WriteAsync(json);
            return Ok();
        }

        [HttpPut]
        [Route("{id}/content")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ServerErrorDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestDTO))]
        public async Task<ActionResult> Put(Guid id)
        {
            //метод найдет хранимый документ и привяжет к нему содержимое. вернёт ОК или ошибку
            //return Ok();
            var path = StoreLogic.GetFullName($"{id}.pdf");
            if (System.IO.File.Exists(path))
            {
                using (FileStream stream = System.IO.File.Open(path, System.IO.FileMode.Open))
                {
                    await Request.Body.CopyToAsync(stream);
                }
                return Ok();
            }
            return new NotFoundResult();
        }
    }
}
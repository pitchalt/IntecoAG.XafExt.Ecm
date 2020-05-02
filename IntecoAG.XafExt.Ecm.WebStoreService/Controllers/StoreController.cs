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
        //[Route("{post}")]
        public async Task<ActionResult<DocDTO>> Post(DocDTO document)
        {
            if (document is null)
            {
                return BadRequest();
            }
            return new DocDTO() {Id = Guid.NewGuid()};
            //Document doc = new Document();
            //doc.Name = Guid.NewGuid().ToString();
            //Response.StatusCode = 201;
            //Response.ContentType = "application/json";
            //Response.Body = new MemoryStream(Encoding.UTF8.GetBytes(doc.Name));
            //return Ok();
        }

        [HttpPost]
        [Route("{id}")]
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
        public async Task<ActionResult> GetContent(Guid id)
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
        public async Task<ActionResult> GetDocument(Guid id)
        {

            return Ok();
        }

        [HttpPut]
        [Route("{id}/content")]
        public async Task<ActionResult> Put(Guid id)
        {
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
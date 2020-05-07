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
using DevExpress.Data.Filtering;

using IntecoAG.XafExt.Ecm.WebStoreService.Swagger;

namespace IntecoAG.XafExt.Ecm.WebStoreService.Controllers
{
    /// <summary>
    /// контролер создания/обновления/получения контента документа
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class StoreController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly IObjectSpace ObjectSpace;
        /// <summary>
        /// открытый конструктор
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="objectSpace"></param>
        public StoreController(ILogger<StoreController> logger, IObjectSpace objectSpace)
        {
            ObjectSpace = objectSpace;
            _logger = logger;
        }
        private readonly ILogger<StoreController> _logger;
        /// <summary>
        /// Создает EcmDocument по данным документа
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(DocDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ServerErrorDTO))]
        public async Task<ActionResult> DocumentCreate(DocDTO document)
        {
            if (document is null)
            {
                return new ObjectResult(new BadRequestDTO());
            }
            //document.Id = Guid.NewGuid();
            var doc = ObjectSpace.CreateObject<EcmDocument>();
            var guid = Guid.NewGuid();
            doc.ObjectId = guid.ToString();
            var uri = this.Url.RouteUrl(this.RouteData);
            //StoreLogic.CreateFile(doc.ObjectId, "pdf");
            document.Id = guid;
            ObjectSpace.CommitChanges();
            return Created(uri, document);
            //Document doc = new Document();
            //doc.Name = Guid.NewGuid().ToString();
            //Response.StatusCode = 201;
            //Response.ContentType = "application/json";
            //Response.Body = new MemoryStream(Encoding.UTF8.GetBytes(doc.Name));
            //return Ok();
        }
        /// <summary>
        /// Обновляет EcmDocument по id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="document"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(DocDTO))]//201 вместо 200 чтобы убрать warning
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ServerErrorDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestDTO))]
        public async Task<ActionResult> DocumentUpdate(Guid id, DocDTO document)
        {
            //Принимает минимальное количество парметров в документе, колдует и позвращает докуменент

            //Document doc = new Document();
            //doc.Name = id;
            //Response.StatusCode = 201;
            //Response.ContentType = "application/json";
            //Response.Body = new MemoryStream(Encoding.UTF8.GetBytes(doc.Name));
            if(document is null)
            {
                return new ObjectResult(new BadRequestDTO());
            }
            CriteriaOperator criteria = new BinaryOperator(nameof(EcmDocument.ObjectId), id.ToString());
            var doc = ObjectSpace.FindObject<EcmDocument>(criteria);
            doc.ObjectId = id.ToString();
            var uri = this.Url.RouteUrl(this.RouteData);
            //StoreLogic.CreateFile(doc.ObjectId, "pdf");
            ObjectSpace.CommitChanges();
            return Created(uri, document);
            //return Ok();
        }

      
        /// <summary>
        /// Возвращает документ по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DocDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ServerErrorDTO))]

        public async Task<ActionResult> DocumentGet(Guid id)
        {
            //var path = StoreLogic.GetFullName($"{id}.pdf");
            //if (!System.IO.File.Exists(path))
            //{
            //    return new NotFoundResult();
            //}
            //var doc = ObjectSpace.GetObjectByKey<EcmDocument>(id);
            CriteriaOperator criteria = new BinaryOperator(nameof(EcmDocument.ObjectId), id.ToString());
            var doc = ObjectSpace.FindObject<EcmDocument>(criteria);
            var docDTO = new DocDTO() { FileName = doc.ObjectId };
            
            return Ok(docDTO);
        }
        /// <summary>
        /// Возвращает контент файла по id/имя файла
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}/content")]
        [ResponseBinaryContent(StatusCodes.Status200OK, "application/pdf")]
//        [ProducesBinaryResponseType(StatusCodes.Status200OK, "application/pdf")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ServerErrorDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestDTO))]
        public async Task<ActionResult> ContentGet(Guid id)
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

            return new ObjectResult(new NotFoundDTO());
        }

        /// <summary>
        /// Создает и задает контент для файла(имя файла = id) 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}/content")]
        [RequestBinaryContent("application/pdf")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ServerErrorDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestDTO))]
        public async Task<ActionResult> ContentSet(Guid id)
        {
            //метод найдет хранимый документ и привяжет к нему содержимое. вернёт ОК или ошибку
            //return Ok();
            //
            CriteriaOperator criteria = new BinaryOperator(nameof(EcmDocument.ObjectId), id.ToString());
            var doc = ObjectSpace.FindObject<EcmDocument>(criteria);
            if (!doc.IsLoaded)
            {
                var path = StoreLogic.GetFullName($"{id}.pdf");
                using (FileStream stream = System.IO.File.Create(path))
                {
                    await Request.Body.CopyToAsync(stream);
                }

                doc.IsLoaded = true;

                return Ok();
            }

            return new NotFoundResult();
        }
    }
}
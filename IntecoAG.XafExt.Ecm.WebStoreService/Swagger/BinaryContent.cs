using System;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace IntecoAG.XafExt.Ecm.WebStoreService.Swagger {

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class RequestBinaryContentAttribute : Attribute {

        public String ContentType { get; }

        public RequestBinaryContentAttribute(String contentType) {
            ContentType = contentType;
        }

    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class ResponseBinaryContentAttribute : Attribute {

        public Int32 StatusCode { get; }
        public String ContentType { get; }

        public ResponseBinaryContentAttribute(Int32 statusCode, String contentType) {
            StatusCode = statusCode;
            ContentType = contentType;
        }

    }

    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class ProducesBinaryResponseTypeAttribute : ProducesResponseTypeAttribute, IApiResponseMetadataProvider {

        public String ContentType { get; }

        public ProducesBinaryResponseTypeAttribute(Int32 statusCode, String contentType):base(statusCode) {
            ContentType = contentType;
        }

        void IApiResponseMetadataProvider.SetContentTypes(MediaTypeCollection contentTypes)
        {
            contentTypes.Add(ContentType);
        }

    }

    public class BinaryContentFilter : IOperationFilter {

        /// <summary>
        /// Configures operations decorated with the <see cref="BinaryContentAttribute" />.
        /// </summary>
        /// <param name="operation">The operation.</param>
        /// <param name="context">The context.</param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context) {
            if (context.MethodInfo.GetCustomAttributes(typeof(RequestBinaryContentAttribute), false)
                       .FirstOrDefault() is RequestBinaryContentAttribute attribute) {
                operation.RequestBody = new OpenApiRequestBody() {Required = true};
                operation.RequestBody.Content.Add(attribute.ContentType,
                    new OpenApiMediaType() {
                        Schema = new OpenApiSchema() {
                            Type = "string",
                            Format = "binary",
                        },
                    });
            }
            
            foreach(ResponseBinaryContentAttribute response_attr in context.MethodInfo.GetCustomAttributes(typeof(ResponseBinaryContentAttribute), false)) {
                if (!operation.Responses.TryGetValue(response_attr.StatusCode.ToString(), out var response)) {
                    response = new OpenApiResponse();
                    operation.Responses[response_attr.StatusCode.ToString()] = response;
                }

                if (!response.Content.TryGetValue(response_attr.ContentType, out var mediaType)) {
                    mediaType = new OpenApiMediaType() {
                        Schema = new OpenApiSchema() {
                            Type = "string",
                            Format = "binary",
                        },
                    };
                    response.Content[response_attr.ContentType] = mediaType;
                }
            }

        }

    }

}
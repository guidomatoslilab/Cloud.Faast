using AutoMapper;
using Cloud.Core.Proteccion;
using Cloud.Faast.Integracion.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Filters
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment env; 
        private readonly ILogger<HttpGlobalExceptionFilter> logger;

        public HttpGlobalExceptionFilter(IWebHostEnvironment env, ILogger<HttpGlobalExceptionFilter> logger)
        {
            this.env = env;
            this.logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            logger.LogError(new EventId(context.Exception.HResult),
                context.Exception,
                context.Exception.Message);

            var globalMessage = context.Exception.Message;

            if (env.EnvironmentName != "Development")
            {
                globalMessage = "No se ha podido procesar su solicitud.";
            }

            var response = new ResponseApi("400", "EOK", globalMessage);

            context.Result = new BadRequestObjectResult(response);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.ExceptionHandled = true;
            GeneralHelper.LogSentryIO(context.Exception);
        }
    }
}

using Cloud.Core.Proteccion;
using Cloud.Faast.Integracion.Utils;
using Cloud.Faast.Integracion.Utils.ActionResults;
using Cloud.Faast.Integracion.Utils.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

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

            ResponseApi response;
            if (context.Exception.GetType() == typeof(IntegracionException))
            {
                response = new ResponseApi("400", "EOK", globalMessage);

                context.Result = new BadRequestObjectResult(response);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.ExceptionHandled = true;
                return;
            }

            if (env.EnvironmentName != "Development")
            {
                globalMessage = "No se ha podido procesar su solicitud.";
            }

            response = new ResponseApi("500", "EOK", globalMessage);

            context.Result = new InternalServerErrorObjectResult(response);
            //context.Result = new BadRequestObjectResult(response);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.ExceptionHandled = true;
            GeneralHelper.LogSentryIO(context.Exception);
        }
    }
}

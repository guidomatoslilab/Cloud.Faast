using Cloud.Core.Proteccion;
using Cloud.Faast.Integracion.Interface.Repository.Persona;
using Cloud.Faast.Integracion.Interface.Repository.Seguridad;
using Cloud.Faast.Integracion.Interface.Service.Seguridad;
using Cloud.Faast.Integracion.Model.Dto.Seguridad;
using Cloud.Faast.Integracion.Service.Seguridad;
using Cloud.Faast.Integracion.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Filters
{
    public class AuthorizationFilter : IActionFilter
    {
        private readonly ISeguridadService _seguridadService;
        private readonly ILogger<AuthorizationFilter> _logger;
        public AuthorizationFilter(ISeguridadService seguridadService, ILogger<AuthorizationFilter> logger)
        {
            _seguridadService = seguridadService;
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public async void OnActionExecuting(ActionExecutingContext context)
        {
            #region Variables Locales

            var request = context.HttpContext.Request;
            string? controller = request.RouteValues["controller"]?.ToString();
            string? metodoAction = request.RouteValues["action"]?.ToString();
            string? endPoint = request.Path;

            #endregion
            try
            {

                #region Validar existencia de parametros en header
                var requestHeader = request.Headers.ToList();

                if (!requestHeader.Any())
                {
                    context.Result = new UnauthorizedObjectResult(new ResponseApi("401", "NOK", "Los parametros de header es requerido"));
                    return;
                }

                HeaderEntity header = new()
                {
                    country = requestHeader.Where(x => x.Key.Equals("country")).FirstOrDefault().Value,
                    provider = requestHeader.Where(x => x.Key.Equals("provider")).FirstOrDefault().Value,
                    apiKey = requestHeader.Where(x => x.Key.Equals("apiKey")).FirstOrDefault().Value
                };

                #endregion

                #region  Validar Header 
                var validaHeader = Security.GetHeaderValidation(header);
                if (validaHeader.httpStatusCode != HttpStatusCode.OK)
                {
                    context.Result = new UnauthorizedObjectResult(new ResponseApi("401", "NOK", validaHeader.statusDescription));
                    return;
                }
                #endregion

                #region LOG CONTRACT


                string sContract = "";

                if (request.Method == HttpMethods.Post && request.ContentLength > 0)
                {
                    string body = await GeneralHelper.ObtenerBodyString(request);

                    sContract = Newtonsoft.Json.JsonConvert.SerializeObject(body);
                }

                string sHeader = Newtonsoft.Json.JsonConvert.SerializeObject(header);
                string sTrace = string.Format("{0};{1};Body= {2};Header= {3}", DateTime.Now.ToString(), endPoint, sContract, sHeader);

                ContratoDto dataItem = new ContratoDto()
                {
                    Controller = controller,
                    Action = metodoAction,
                    FechaCreacion = DateTime.Now,
                    Contrato = sTrace
                };
                _seguridadService.Guardar(dataItem);

                #endregion

                #region  Validar Api Key
                var validaApiKey = Security.GetValidationApiKey(header.apiKey);
                //if (validaApiKey.httpStatusCode != HttpStatusCode.OK)
                //{
                //    context.Result = new UnauthorizedObjectResult(new ResponseApi("401", "NOK", validaApiKey.statusDescription));
                //    return;
                //}
                #endregion

                #region Validar Credenciales API KEY

                Core.Proteccion.ApiKeyEntity keyEntity = Security.GetApiKey(header.apiKey);

                if (keyEntity == null)
                {
                    context.Result = new UnauthorizedObjectResult(new ResponseApi("401", "NOK", "Key no puede ser validado de las credenciales enviadas."));
                    return;
                }

                ContratoApiKeyDto dataApiKey = _seguridadService.ObtenerApiKey(keyEntity.method, header.apiKey, header.provider, header.country);

                if (dataApiKey == null)
                {
                    context.Result = new UnauthorizedObjectResult(new ResponseApi("401", "NOK", "Key es inválido."));
                    return;
                }

                if (!dataApiKey.Status)
                {
                    context.Result = new UnauthorizedObjectResult(new ResponseApi("401", "NOK", "Key se encuentra inactivo."));
                    return;
                }

                #endregion
            }
            catch (Exception ex)
                {
                context.Result = new UnauthorizedObjectResult(new ResponseApi("401", "NOK", ""));

                GeneralHelper.LogSentryIO(ex);
                try
                {
                    _logger.LogError(ex, metodoAction);

                }
                catch (Exception ex1)
                {

                    throw;
                }
                return;
            }
        }
    }
}

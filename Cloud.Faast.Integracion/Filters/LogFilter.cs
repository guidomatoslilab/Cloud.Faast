using Cloud.Core.Proteccion;
using Cloud.Faast.Integracion.Interface.Service.Common.Seguridad;
using Cloud.Faast.Integracion.Model.Dto.Common.Seguridad;
using Cloud.Faast.Integracion.Utils;
using Cloud.Faast.Integracion.ViewModel.Common.Seguridad;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Filters
{
    public class LogFilter : IActionFilter
    {
        private readonly ISeguridadService _seguridadService;
        private readonly ILogger<AuthorizationFilter> _logger;

        public LogFilter(ISeguridadService seguridadService, ILogger<AuthorizationFilter> logger)
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
            string endPoint = request.Path;

            #endregion

            try
            {

                #region LOG CONTRACT

                var requestHeader = request.Headers.ToList();

                HeaderRequestViewModel header = new()
                {
                    User = requestHeader.Where(x => x.Key.Equals("User")).FirstOrDefault().Value,
                    Authorization = requestHeader.Where(x => x.Key.Equals("Authorization")).FirstOrDefault().Value
                };


                string sContract = "";

                if (request.Method == HttpMethods.Post && request.ContentLength > 0)
                {
                    string body = await HttpHelper.ObtenerBodyString(request);

                    sContract = Newtonsoft.Json.JsonConvert.SerializeObject(body);
                }

                string sHeader = Newtonsoft.Json.JsonConvert.SerializeObject(header);
                string sTrace = string.Format("{0};{1};Body= {2};Header= {3}", DateTime.Now.ToString(), endPoint, sContract, sHeader);

                ContratoDto dataItem = new()
                {
                    Controller = controller,
                    Action = metodoAction,
                    FechaCreacion = DateTime.Now,
                    Contrato = sTrace
                };
                _seguridadService.Guardar(dataItem);

                #endregion
            }
            catch (Exception ex)
            {

                context.Result = new UnauthorizedObjectResult(new ResponseApi(Variables.CodigosRespuesta.UNAUTHORIZED.ToString(), Variables.EstadosRespuesta.NOK, ""));

                GeneralHelper.LogSentryIO(ex);

                _logger.LogError(ex, metodoAction);

                return;
            }
        }
    }
}

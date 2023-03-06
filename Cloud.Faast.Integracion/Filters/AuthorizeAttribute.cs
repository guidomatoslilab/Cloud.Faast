using Cloud.Core.Proteccion;
using Cloud.Faast.Integracion.Model.Dto.Common.Seguridad;
using Cloud.Faast.Integracion.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Sentry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            // authorization
            int? userId = (int?)context.HttpContext.Items["UsuarioIntegracionId"];
            if (userId == null)
                context.Result = new JsonResult(new ResponseApi(Variables.CodigosRespuesta.UNAUTHORIZED.ToString(), Variables.EstadosRespuesta.NOK, "Token es inválido", null)) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}

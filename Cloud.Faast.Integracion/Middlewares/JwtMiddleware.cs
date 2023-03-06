using Cloud.Faast.Integracion.Interface.Service.Common.Seguridad;
using Cloud.Faast.Integracion.Utils;

namespace Cloud.Faast.Integracion.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ISeguridadService seguridadService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var usuario = context.Request.Headers["User"].FirstOrDefault();


            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(usuario))
            {
                await _next(context);
                return;
            }

            var usuarioEncontrado = seguridadService.ObtenerPorUsuario(usuario);

            if (usuarioEncontrado is null)
            {
                await _next(context);
                return;
            }

            var userId = JwtHelper.ValidateToken(token, usuarioEncontrado.SecretKey);
            if (userId != null)
            {
                // attach user to context on successful jwt validation
                context.Items["UsuarioIntegracionId"] = userId;
            }

            await _next(context);
        }
    }
}
using Cloud.Core.Proteccion;
using Cloud.Faast.Integracion.ViewModel.Common.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Utils
{
    public static class HttpHelper
    {
        public static async Task<string> ObtenerBodyString(this HttpRequest request, Encoding? encoding = null)
        {
            if (!request.Body.CanSeek)
            {
                // We only do this if the stream isn't *already* seekable,
                // as EnableBuffering will create a new stream instance
                // each time it's called
                request.EnableBuffering();
            }

            request.Body.Position = 0;

            var reader = new StreamReader(request.Body, encoding ?? Encoding.UTF8);

            var body = await reader.ReadToEndAsync().ConfigureAwait(false);

            request.Body.Position = 0;

            return body;
        }


        public static ResponseHttpStatus ValidarHeaderPorToken(HeaderRequestViewModel header)
        {
            ResponseHttpStatus responseHttpStatus = new ResponseHttpStatus();

            if (string.IsNullOrEmpty(header.User))
            {
                responseHttpStatus.httpStatusCode = HttpStatusCode.Ambiguous;
                responseHttpStatus.statusDescription = "Headers [User no está codificado correctamente]";
                return responseHttpStatus;
            }

            if (string.IsNullOrEmpty(header.Authorization))
            {
                responseHttpStatus.httpStatusCode = HttpStatusCode.Ambiguous;
                responseHttpStatus.statusDescription = "Headers [Authorization no está codificado correctamente]";
                return responseHttpStatus;
            }

            responseHttpStatus.httpStatusCode = HttpStatusCode.OK;
            responseHttpStatus.statusDescription = string.Empty;
            return responseHttpStatus;
        }
    }
}

using Sentry;
using System.Text;

namespace Cloud.Faast.Integracion.Utils
{
    public static class GeneralHelper
    {
        public static void LogSentryIO(Exception ex)
        {
            ex.Data.Add("Stack trace", ex.StackTrace);
            SentrySdk.CaptureException(ex);
        }

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
    }
}

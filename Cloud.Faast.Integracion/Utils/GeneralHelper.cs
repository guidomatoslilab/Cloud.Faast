using Sentry;

namespace Cloud.Faast.Integracion.Utils
{
    public static class GeneralHelper
    {
        public static void LogSentryIO(Exception ex)
        {
            ex.Data.Add("Stack trace", ex.StackTrace);
            SentrySdk.CaptureException(ex);
        }
    }
}

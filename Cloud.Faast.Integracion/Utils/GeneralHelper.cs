using Sentry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

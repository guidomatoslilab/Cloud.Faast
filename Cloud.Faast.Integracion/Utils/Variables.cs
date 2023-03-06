namespace Cloud.Faast.Integracion.Utils
{
    public static class Variables
    {
        public static class CodigosRespuesta
        {
            public const int OK = StatusCodes.Status200OK;
            public const int ERROR = StatusCodes.Status500InternalServerError;
            public const int BADREQUEST = StatusCodes.Status400BadRequest;
            public const int UNAUTHORIZED = StatusCodes.Status401Unauthorized;
            public const int NOTFOUND = StatusCodes.Status404NotFound;
        }

        public static class MensajesRespuesta
        {
            public const string OK = "La operación se realizó con éxito";
            public const string NOTFOUND = "No se encontró el recurso solicitado";
            public const string ERROR = "Lo sentimos, algo salió mal. Intenta de nuevo mas tarde";
        }

        public static class EstadosRespuesta
        {
            public const string NOK = "NOK";
            public const string OK = "OK";
            public const string EOK = "EOK";
        }
    }
}

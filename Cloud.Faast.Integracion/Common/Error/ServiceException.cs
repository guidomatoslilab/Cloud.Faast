namespace Cloud.Faast.Integracion.Common.Error
{
    public class ServiceException : Exception
    {
        public string Code { get; set; } = "";

        public ServiceException(string messsage)
            : base(messsage)
        {
        }

        public ServiceException(string code, string message)
            : base(message)
        {
            Code = code;
        }
    }
}

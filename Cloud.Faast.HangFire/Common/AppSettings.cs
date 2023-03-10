namespace Cloud.Faast.HangFire.Common
{
    public class AppSettings
    {
        public Orsan Orsan { get; set; } = new Orsan();
    }
    public class Orsan
    {
        public FTP FTP { get; set; } = new FTP();
    }
    public class FTP
    {
        public string Host { get; set; } = "";
        public int Port { get; set; }
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
        public string RutaArchivoLocal { get; set; } = "";
        public string CarpetaDestino { get; set; } = "";
    }
}

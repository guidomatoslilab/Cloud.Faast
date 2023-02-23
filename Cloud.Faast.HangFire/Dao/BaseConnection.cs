namespace Cloud.Faast.HangFire.Dao
{
    public class BaseConnection
    {
        protected static IConfiguration _baseConfiguration;

        public IConfiguration BaseConfiguration
        { get { return _baseConfiguration; } }

        public BaseConnection(IConfiguration _configuration)
        {
            _baseConfiguration = _configuration;
        }

    }
}

using System.Data;
using System.Data.SqlClient;
using static Cloud.Faast.HangFire.Common.Constantes;

namespace Cloud.Faast.HangFire.Dao
{
    public class Sql: BaseConnection
    {
        public Sql(IConfiguration _configuration) : base(_configuration)
        {
            _baseConfiguration = _configuration;
        }

        public static IDbConnection ObtenerConexion(Enum baseDatos)
        {
            string connectionStringName;
            switch (baseDatos)
            {
                case BaseDatos.FastOrsan:
                    connectionStringName = _baseConfiguration.GetConnectionString("FastOrsan");
                    break;
                default:
                    connectionStringName = _baseConfiguration.GetConnectionString("FastOrsan");
                    break;
            }

            return new SqlConnection(connectionStringName);
        }
    }
}

using System.Data;
using Cloud.Faast.HangFire.Interface.Repository.Orsan;
using Cloud.Faast.HangFire.Model.Dto.Orsan;
using static Cloud.Faast.HangFire.Common.Constantes;

namespace Cloud.Faast.HangFire.Dao.Repository.Orsan
{
    public class OperacionDocumentoRepository : BaseConnection, IOperacionDocumentoRepository
    {

        public OperacionDocumentoRepository(IConfiguration configuration)
            : base(configuration)
        {

        }

        public List<ReporteOperacionDocumentoResponseDto> ObtenerReporteOperacionDocumento()
        {
            var listObjetoAlter = new List<ReporteOperacionDocumentoResponseDto>();

            using (var dbConnection = Sql.ObtenerConexion(BaseDatos.FastOrsan))
            {
                dbConnection.Open();
                using (var cmd = dbConnection.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.GetCustomer";

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var objeto = new ReporteOperacionDocumentoResponseDto
                            {
                                CustomerName = dr["CustomerName"].ToString()
                            };

                            listObjetoAlter.Add(objeto);
                        }
                    }
                }
                dbConnection.Close();
            }
            return listObjetoAlter;
        }
    }
}

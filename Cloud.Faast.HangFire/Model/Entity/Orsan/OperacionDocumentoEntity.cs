using Cloud.Faast.HangFire.Interface.Repository;

namespace Cloud.Faast.HangFire.Model.Entity.Orsan
{
    public class OperacionDocumentoEntity: IGenerateIdentity<OperacionDocumentoEntity>
    {
        public long Id { get; set; }
        public string? RutCliente { get; set; } = "";
        public string? RazonSocialCliente { get; set; } = "";
        public string? RutDeudor { get; set; } = "";
        public string? RazonSocialDeudor { get; set; } = "";
        public int NumeroOperacion { get; set; }
        public string? CodigoTipoDocumento { get; set; } = "";
        public decimal NumeroDocumento { get; set; }
        public string? FechaCesion { get; set; }
        public string? PorcentajeAnticipado { get; set; }
        public string? MontoDocumento { get; set; }
        public string? MontoSaldoDeudor { get; set; }
        public string? MontoAnticipado { get; set; }
        public string? MontoSaldoCliente { get; set; }
        public string? CodigoEstadoDocumento { get; set; }
        public string? FechaVencimiento { get; set; }
        public string? FechaVencimientoReal { get; set; }
        public int CantidadDiasMora { get; set; }
        public string? NumeroFacturaDP { get; set; }
        public string? FechaAbono { get; set; }
        public string? FechaGestion { get; set; }
        public string? ComentarioGestion { get; set; }
        public string? NombreEjecutivoCobranza { get; set; }
        public string? NombreEjecutivo { get; set; }
        public int CodigoEstadoCobranza { get; set; }
        public string? NombreEstadoGestion { get; set; }
        public string? NombreSucursal { get; set; }
        public string? MontoLineaAprobada { get; set; }
        public string? MontoLineaDisponible { get; set; }
        public string? Tramo { get; set; }
        public string? NombreGrupo { get; set; }
        public string? NombreTamanioEmpresaCliente { get; set; }
        public string? NombreTerminoGiroCliente { get; set; }
        public string? MontoVentaUfCliente { get; set; }
        public string? NombreTamanioEmpresaDeudor { get; set; }
        public string? NombreTerminoGiroDeudor { get; set; }
        public string? MontoVentaUfDeudor { get; set; }

        public Func<OperacionDocumentoEntity> GetKey()
        {
            return () => new OperacionDocumentoEntity { Id = Id };
        }
    }
}

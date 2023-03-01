using AutoMapper;
using Cloud.Faast.HangFire.Model.Dto.Orsan;
using Cloud.Faast.HangFire.Model.Entity.Orsan;

namespace Cloud.Faast.HangFire.MapperProfiles.Orsan.OperacionDocumento
{
    public class OperacionDocumentoProfile : Profile
    {
        public OperacionDocumentoProfile() {
            CreateMap<OperacionDocumentoEntity, ReporteOperacionDocumentoResponseDto>();
        }
    }
}

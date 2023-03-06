using Cloud.Faast.Integracion.Interface.Repository;

namespace Cloud.Faast.Integracion.Model.Entity.Metriks.Persona
{
    public class PersonaEntity : AuditBase, IGenerateIdentity<PersonaEntity>
    {
        public int prg_int_idpersona { get; set; }
        public string? prg_vch_rut { get; set; }
        public string? prg_vch_razonsocial { get; set; }
        public string? prg_vch_nombre { get; set; }
        public int prg_int_idtipo { get; set; }

        public Func<PersonaEntity> GetKey()
        {
            return () => new PersonaEntity { prg_int_idpersona = prg_int_idpersona };
        }
    }
}

using System;
using System.Collections.Generic;

namespace SOFTWARE_SP_MEDICAL_GROUP.Domains
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Medicos = new HashSet<Medicos>();
            ProntuariosPacientes = new HashSet<ProntuariosPacientes>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int IdTipoUsario { get; set; }

        public TiposUsuario IdTipoUsarioNavigation { get; set; }
        public ICollection<Medicos> Medicos { get; set; }  //Isso também precisa ser colocado no postman (ver as requests)
        public ICollection<ProntuariosPacientes> ProntuariosPacientes { get; set; } //Isso também precisa ser colocado no postman
    }
}

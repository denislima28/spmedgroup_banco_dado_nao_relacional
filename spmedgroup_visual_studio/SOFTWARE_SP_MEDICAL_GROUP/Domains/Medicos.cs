using System;
using System.Collections.Generic;

namespace SOFTWARE_SP_MEDICAL_GROUP.Domains
{
    public partial class Medicos
    {
        public Medicos()
        {
            Consultas = new HashSet<Consultas>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Crm { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public int IdUsuario { get; set; }
        public int IdEspecialidade { get; set; }
        public int IdClinica { get; set; }

        public Clinicas IdClinicaNavigation { get; set; }
        public Especialidades IdEspecialidadeNavigation { get; set; }
        public Usuarios IdUsuarioNavigation { get; set; }
        public ICollection<Consultas> Consultas { get; set; }
    }
}

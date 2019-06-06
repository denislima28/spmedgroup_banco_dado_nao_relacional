using System;
using System.Collections.Generic;

namespace SOFTWARE_SP_MEDICAL_GROUP.Domains
{
    public partial class Consultas
    {
        public int Id { get; set; }
        public DateTime DataConsulta { get; set; }
        public string Situacao { get; set; }
        public string Descricao { get; set; }
        public int IdMedico { get; set; }
        public int IdProntuarioPaciente { get; set; }

        public Medicos IdMedicoNavigation { get; set; }
        public ProntuariosPacientes IdProntuarioPacienteNavigation { get; set; }
    }
}

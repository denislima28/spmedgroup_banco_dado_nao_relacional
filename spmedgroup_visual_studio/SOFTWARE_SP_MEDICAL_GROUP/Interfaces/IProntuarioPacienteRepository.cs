using SOFTWARE_SP_MEDICAL_GROUP.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOFTWARE_SP_MEDICAL_GROUP.Interfaces
{
    interface IProntuarioPacienteRepository
    {
        void Cadastrar(ProntuariosPacientes prontuariopaciente);

        void Alterar(ProntuariosPacientes prontuariopaciente); //Com a framework, não precisa passar o ID nesse método.

        List<ProntuariosPacientes> ListarProntuariosPacientes();

        void Deletar(int Id);
    }
}

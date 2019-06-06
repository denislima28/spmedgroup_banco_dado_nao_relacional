using SOFTWARE_SP_MEDICAL_GROUP.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOFTWARE_SP_MEDICAL_GROUP.Interfaces
{
    interface IConsultaRepository
    {
        void Cadastrar(Consultas consulta);

        void CancelarAgendamento(Consultas consulta);
        //Altera o status de "Agendada" para "Cancelada"

        List<Consultas> ListarConsultas(int idusuario, string tipousuario);

            /*
        List<Consultas> ListarConsultas();
        //só adm pode fazer

        List<Consultas> ListarConsultasMedico(int idmedico);
        //só adm e médico podem fazer

        List<Consultas> ListarConsultasPaciente();
        //só adm e paciente podem fazer*/

        void AlterarDescricao(Consultas consulta);
        //Talvez alterar o parâmetro para que o médico 
        //possa modificar apenas a descriçaõ.
    }
}
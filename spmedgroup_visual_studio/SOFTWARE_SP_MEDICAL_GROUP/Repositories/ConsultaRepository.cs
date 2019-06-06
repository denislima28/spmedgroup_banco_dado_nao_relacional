using Microsoft.EntityFrameworkCore;
using SOFTWARE_SP_MEDICAL_GROUP.Domains;
using SOFTWARE_SP_MEDICAL_GROUP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOFTWARE_SP_MEDICAL_GROUP.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        /*
         * public void Alterar(Usuarios usuario)
        {
            using (SpmedgroupContext ctx = new SpmedgroupContext())
            {
                ctx.Usuarios.Update(usuario);
                ctx.SaveChanges();
            }
        }
         */

        //O código serve para que a gente altere a descrição digitando apenas os campos id e descrição.
        //Não é preciso digitar os demais.
        public void AlterarDescricao(Consultas consulta)
        {
            using (SpmedgroupContext ctx = new SpmedgroupContext())
            {                         
                ctx.Consultas.Attach(consulta);

                ctx.Entry(consulta).Property(u => u.Descricao).IsModified = true;

                ctx.SaveChanges();
            }    
        }

        //O código serve para que a gente altere a descrição digitando apenas os campos id e situação.
        //Não é preciso digitar os demais.
        public void Cadastrar(Consultas consulta)
        {
            using (SpmedgroupContext ctx = new SpmedgroupContext())
            {
                ctx.Consultas.Add(consulta);
                ctx.SaveChanges();
            }
        }

        //O código serve para que a gente altere a situacao digitando apenas os campos id e situação.
        //Não é preciso digitar os demais.
        public void CancelarAgendamento(Consultas consulta)
        {
            using (SpmedgroupContext ctx = new SpmedgroupContext())
            {
                ctx.Consultas.Attach(consulta);

                ctx.Entry(consulta).Property(u => u.Situacao).IsModified = true;

                ctx.SaveChanges();
            }
        }

        public List<Consultas> ListarConsultas(int idusuario, string tipousuario) //cada um só pode ver as próprias consultas. ADM pode ver todas.
        {
            using (SpmedgroupContext ctx = new SpmedgroupContext())
            {
                if (tipousuario == "ADM")
                {
                    return ctx.Consultas.Include(x => x.IdMedicoNavigation).Include(x => x.IdProntuarioPacienteNavigation).ToList();
                }

                if (tipousuario == "Medico")
                {
                    Medicos medico;

                    medico = ctx.Medicos.FirstOrDefault(x => x.IdUsuario == idusuario); //faz a ligação das tabelas Medicos e Usuarios

                    return ctx.Consultas.Where(x => x.IdMedico == medico.Id).Include(x => x.IdMedicoNavigation).ToList();
                    //o where faz a ligação das tabelas Consultas e Medicos, listando as consultas pedidas.

                }

                if (tipousuario == "Paciente")
                {
                    ProntuariosPacientes prontuariopaciente;

                    prontuariopaciente = ctx.ProntuariosPacientes.FirstOrDefault(x => x.IdUsuario == idusuario);

                    return ctx.Consultas.Where(x => x.IdProntuarioPaciente == prontuariopaciente.Id).Include(x => x.IdProntuarioPacienteNavigation).ToList();

                }

                return null;
            }
           
        }


        /*
        public List<Consultas> ListarConsultas()
        {

            using (SpmedgroupContext ctx = new SpmedgroupContext())
            {
                return ctx.Consultas.ToList();
            }
        }

        public List<Consultas> ListarConsultasMedico(int id)
        {
            using (SpmedgroupContext ctx = new SpmedgroupContext())
            {

                return ctx.Consultas.Where(x => x.IdMedico == id).ToList();

                Consultas consultasProcuradas = ctx.Consultas.Include(x => x.IdMedicoNavigation).FirstOrDefault(x => x.IdMedico == id);
                return ctx.Consultas.ToList();  Esse está errado. Faz aparecer todas as consultas e faz aparecer as informações do médico nas
                consulta requerida.
            }
        }

        public List<Consultas> ListarConsultasPaciente()
        {
            throw new NotImplementedException();
        }*/
    }
}

using SOFTWARE_SP_MEDICAL_GROUP.Domains;
using SOFTWARE_SP_MEDICAL_GROUP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOFTWARE_SP_MEDICAL_GROUP.Repositories
{
    public class ProntuarioPacienteRepository : IProntuarioPacienteRepository
    {
        public void Alterar(ProntuariosPacientes prontuariopaciente)
        {
            using (SpmedgroupContext ctx = new SpmedgroupContext())
            {
                ctx.ProntuariosPacientes.Update(prontuariopaciente);
                ctx.SaveChanges();
            }
        }

        public void Cadastrar(ProntuariosPacientes prontuariopaciente)
        {
            using (SpmedgroupContext ctx = new SpmedgroupContext())
            {
                ctx.ProntuariosPacientes.Add(prontuariopaciente);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int Id)
        {
            using (SpmedgroupContext ctx = new SpmedgroupContext())
            {
                ProntuariosPacientes prontuariopacienteProcurado = ctx.ProntuariosPacientes.Find(Id);
                //Dá para fazer sem essa linha, mas aí o parâmetro seria ProntuariosPacientes prontuariopaciente, 
                //tendo que mandar todos os dados no Postman

                ctx.ProntuariosPacientes.Remove(prontuariopacienteProcurado);
                ctx.SaveChanges();
            }
        }

        public List<ProntuariosPacientes> ListarProntuariosPacientes()
        {
            using (SpmedgroupContext ctx = new SpmedgroupContext())
            {
                return ctx.ProntuariosPacientes.ToList();
            }
        }
    }
}

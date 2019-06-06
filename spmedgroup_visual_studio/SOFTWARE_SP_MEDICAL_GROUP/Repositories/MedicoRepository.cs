using SOFTWARE_SP_MEDICAL_GROUP.Domains;
using SOFTWARE_SP_MEDICAL_GROUP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOFTWARE_SP_MEDICAL_GROUP.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        public void Alterar(Medicos medico)
        {
            using (SpmedgroupContext ctx = new SpmedgroupContext())
            {
                ctx.Medicos.Update(medico);
                ctx.SaveChanges();
            }
        }

        public void Cadastrar(Medicos medico)
        {
            using (SpmedgroupContext ctx = new SpmedgroupContext())
            {
                ctx.Medicos.Add(medico);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int Id)
        {
            using (SpmedgroupContext ctx = new SpmedgroupContext())
            {
                Medicos medicoProcurado = ctx.Medicos.Find(Id);
                //Dá para fazer sem essa linha, mas aí o parâmetro seria Medicos medico, 
                //tendo que mandar todos os dados no Postman

                ctx.Medicos.Remove(medicoProcurado);
                ctx.SaveChanges();
            }
        }

        public List<Medicos> ListarMedicos()
        {
            using (SpmedgroupContext ctx = new SpmedgroupContext())
            {
                return ctx.Medicos.ToList();
            }
        }
    }
}


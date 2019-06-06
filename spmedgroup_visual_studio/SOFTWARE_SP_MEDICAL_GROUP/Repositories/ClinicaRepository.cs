using SOFTWARE_SP_MEDICAL_GROUP.Domains;
using SOFTWARE_SP_MEDICAL_GROUP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOFTWARE_SP_MEDICAL_GROUP.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        public void Alterar(Clinicas clinica)
        {
            using (SpmedgroupContext ctx = new SpmedgroupContext())
            {
                ctx.Clinicas.Update(clinica);
                ctx.SaveChanges();
            }
        }

        public void Cadastrar(Clinicas clinica)
        {
            using (SpmedgroupContext ctx = new SpmedgroupContext())
            {
                ctx.Clinicas.Add(clinica);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int Id)
        {
            using (SpmedgroupContext ctx = new SpmedgroupContext())
            {
                Clinicas clinicaProcurada = ctx.Clinicas.Find(Id);
                //Dá para fazer sem essa linha, mas aí o parâmetro seria Clinicas clinica, tendo que mandar
                //todos os dados no Postman

                ctx.Clinicas.Remove(clinicaProcurada);
                ctx.SaveChanges();
            }
        }

        public List<Clinicas> ListarClinicas()
        {
            using (SpmedgroupContext ctx = new SpmedgroupContext())
            {
                return ctx.Clinicas.ToList();
            }
        }
    }
}

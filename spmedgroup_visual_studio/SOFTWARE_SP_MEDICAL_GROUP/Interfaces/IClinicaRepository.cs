using SOFTWARE_SP_MEDICAL_GROUP.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOFTWARE_SP_MEDICAL_GROUP.Interfaces
{
    interface IClinicaRepository
    {
        void Cadastrar(Clinicas clinica);

        void Alterar(Clinicas clinica); //Com a framework, não precisa passar o ID nesse método.

        List<Clinicas> ListarClinicas();

        void Deletar(int Id);
    }
}

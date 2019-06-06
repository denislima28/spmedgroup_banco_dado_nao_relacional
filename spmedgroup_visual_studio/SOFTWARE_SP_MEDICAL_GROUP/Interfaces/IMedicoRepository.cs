using SOFTWARE_SP_MEDICAL_GROUP.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOFTWARE_SP_MEDICAL_GROUP.Interfaces
{
    interface IMedicoRepository
    {
        void Cadastrar(Medicos medico);

        void Alterar(Medicos medico); //Com a framework, não precisa passar o ID nesse método.

        List<Medicos> ListarMedicos();

        void Deletar(int Id);
    }
}


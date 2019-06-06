using SOFTWARE_SP_MEDICAL_GROUP.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOFTWARE_SP_MEDICAL_GROUP.Interfaces
{
    interface IUsuarioRepository
    {
        void Cadastrar(Usuarios usuario);

        void Alterar(Usuarios usuario); //Com a framework, não precisa passar o ID nesse método.

        List<Usuarios> ListarUsuarios();

        void Deletar(int Id);

        Usuarios BuscarPorEmailSenha(string email, string senha);
    }
}

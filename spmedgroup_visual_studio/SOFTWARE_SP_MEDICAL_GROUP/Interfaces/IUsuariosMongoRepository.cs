using SOFTWARE_SP_MEDICAL_GROUP.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOFTWARE_SP_MEDICAL_GROUP.Interfaces
{
    public interface IUsuariosMongoRepository
    {
        void Cadastrar(UsuariosMongo usuario);

        List<UsuariosMongo> ListarTodos();

        //UsuariosMongo BuscarPorEmailSenha(string email, string senha);
    }
}

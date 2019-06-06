using Microsoft.EntityFrameworkCore;
using SOFTWARE_SP_MEDICAL_GROUP.Domains;
using SOFTWARE_SP_MEDICAL_GROUP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOFTWARE_SP_MEDICAL_GROUP.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public void Alterar(Usuarios usuario)
        {
            using (SpmedgroupContext ctx = new SpmedgroupContext())
            {
                ctx.Usuarios.Update(usuario);
                ctx.SaveChanges();
            }
        }

        public Usuarios BuscarPorEmailSenha(string email, string senha) //Estão em minúscula porque se referem ao que o usuário digitou,
                                                                        // não ao que está no sistema.
        {
            using (SpmedgroupContext ctx = new SpmedgroupContext())
            {
                Usuarios usuarioProcurado = ctx.Usuarios.Include(x => x.IdTipoUsarioNavigation).FirstOrDefault(x => x.Email == email && x.Senha == senha);
                //FirstorDefault é usado para quando são dois valores. O Include é usado para fazer a junção da tabela USUARIOS e TIPOUSUARIO.
                //Daria para fazer sem o include, mas aí eu teria que mandar "1" em vez de "ADM" nos Roles.
                return usuarioProcurado;
            }
        }

        public void Cadastrar(Usuarios usuario)
        {
            using (SpmedgroupContext ctx = new SpmedgroupContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int Id)
        {
            using (SpmedgroupContext ctx = new SpmedgroupContext())
            {
                Usuarios usuarioProcurado = ctx.Usuarios.Find(Id);
                //Dá para fazer sem essa linha, mas aí o parâmetro seria Usuarios usuario, tendo que mandar
                //todos os dados no Postman
                
                ctx.Usuarios.Remove(usuarioProcurado);
                ctx.SaveChanges();
            }
        }

        public List<Usuarios> ListarUsuarios()
        {
            using (SpmedgroupContext ctx = new SpmedgroupContext())
            {
                return ctx.Usuarios.Include(x => x.IdTipoUsarioNavigation).ToList();
                //É preciso colocar o include para fazer o nome do tipo de usuário aparecer em vez do número.
                //Além disso, também é preciso fazer um ajuste no código que vai exibir os dados da tabela na API.
                //Vide arquivo UsuariosListar no Visual Code
            }
        }
    }
}

using MongoDB.Driver;
using SOFTWARE_SP_MEDICAL_GROUP.Domains;
using SOFTWARE_SP_MEDICAL_GROUP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOFTWARE_SP_MEDICAL_GROUP.Repositories
{
    public class UsuariosMongoRepository : IUsuariosMongoRepository
    {
        private readonly IMongoCollection<UsuariosMongo> _usuarios; //fazendo a conexao com o mongo

        public UsuariosMongoRepository()  //fazendo a conexao com o mongo
        {
            var client = new MongoClient("mongodb://localhost:27017");  //como 27017 é a porta padrão do mongo, ela não precisava ter sido digitada aí
            var database = client.GetDatabase("mongospmedgroup"); //chamando o banco de dados a ser usado
            _usuarios = database.GetCollection<UsuariosMongo>("usuarios");  //chamando a tabela a ser usada
        }

        //Estão em minúscula porque se referem ao que o usuário digitou, não ao que está no sistema.
        public UsuariosMongo BuscarPorEmailSenha(string email, string senha)
        {

            UsuariosMongo usuarioBuscado = _usuarios.Find(x => x.Email == email && x.Senha == senha).FirstOrDefault();

            return usuarioBuscado;
        }

        public void Cadastrar(UsuariosMongo usuariomongo)
        {
            _usuarios.InsertOne(usuariomongo);
        }

        //ainda não funciona
        //public void Deletar(string Id)
        //{
        //    UsuariosMongo usuarioProcurado = _usuarios.Find(Id).FirstOrDefault();

        //    _usuarios.Remove(usuarioProcurado);
        //}

        public List<UsuariosMongo> ListarTodos()
        {
            return _usuarios.Find(_ => true).ToList();  //o que tiver de assíncrono vira síncrono
            //Normalmente, pede um filtro
            //não é recomendável porque a comunicação continua aberta, mas serve para o que estamos fazendo
        }
    }
}

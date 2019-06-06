using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOFTWARE_SP_MEDICAL_GROUP.Domains
{
    public class UsuariosMongo
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("email")]
        [BsonRequired]
        public string Email { get; set; }

        [BsonElement("senha")]
        [BsonRequired]
        public string Senha { get; set; }

        [BsonElement("tipo_usuario")]
        [BsonRequired]
        public string Tipo_usuario  { get; set; }

        [BsonElement("especialidade")]
        public string Especialidade { get; set; }

        [BsonElement("doenca")]
        public string Doenca { get; set; }

        [BsonElement("latitude")] //"apelido" que será usado no mongo
        public string Latitude { get; set; }

        [BsonElement("longitude")] //"apelido" que será usado no mongo
        public string Longitude { get; set; }

    }
}

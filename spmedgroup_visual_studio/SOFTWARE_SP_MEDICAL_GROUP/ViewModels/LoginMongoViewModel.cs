using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOFTWARE_SP_MEDICAL_GROUP.ViewModels
{
    public class LoginMongoViewModel
    {
        [BsonElement("email")]
        [BsonRequired]
        public string Email { get; set; }

        [BsonElement("senha")]
        [BsonRequired]
        public string Senha { get; set; }
    }
}

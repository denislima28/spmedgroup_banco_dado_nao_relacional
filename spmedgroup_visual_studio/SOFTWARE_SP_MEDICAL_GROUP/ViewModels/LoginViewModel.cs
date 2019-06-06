using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//Com o ViewModel, os usuários podem apenas mandar e-mail e senha

namespace SOFTWARE_SP_MEDICAL_GROUP.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "A senha deve ter de 3 a 100 caracteres")]
        public string Senha { get; set; }
    }
}

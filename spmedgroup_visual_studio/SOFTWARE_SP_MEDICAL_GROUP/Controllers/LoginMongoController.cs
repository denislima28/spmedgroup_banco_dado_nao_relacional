using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SOFTWARE_SP_MEDICAL_GROUP.Domains;
using SOFTWARE_SP_MEDICAL_GROUP.Interfaces;
using SOFTWARE_SP_MEDICAL_GROUP.Repositories;
using SOFTWARE_SP_MEDICAL_GROUP.ViewModels;

namespace SOFTWARE_SP_MEDICAL_GROUP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginMongoController : ControllerBase
    {
        private IUsuariosMongoRepository UsuarioMongoRepository { get; set; }

        public LoginMongoController()
        {
            UsuarioMongoRepository = new UsuariosMongoRepository();
        }

        //[HttpPost]
        //public IActionResult Post(LoginMongoViewModel login) //Se colocar "usuario" em vez de "login", vai dar conflito com o UsuarioDomain usuario.
        //{
        //    try
        //    {
        //        UsuariosMongo usuario = UsuariosMongoRepository.BuscarPorEmailSenha(login.Email, login.Senha);

        //        if (usuario == null)
        //        {
        //            return NotFound(new { mensagem = "Usuário não encontrado" });
        //        }

        //        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("spmedgroup-chave-autenticacao"));

        //        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //        var token = new JwtSecurityToken(
        //            issuer: "Spmedgroup.WebApi",
        //            audience: "Spmedgroup.WebApi",
        //            expires: DateTime.Now.AddMinutes(30),
        //            signingCredentials: creds);

        //        return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { mensagem = "Deu erro!!!" });
        //    }

        //}
    }
}

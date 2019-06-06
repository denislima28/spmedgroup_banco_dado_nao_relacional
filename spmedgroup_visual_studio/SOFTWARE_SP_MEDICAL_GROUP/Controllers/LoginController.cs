using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

        public LoginController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(LoginViewModel login) //Se colocar "usuario" em vez de "login", vai dar conflito com o UsuarioDomain usuario.
        {
            try
            {
                Usuarios usuario = UsuarioRepository.BuscarPorEmailSenha(login.Email, login.Senha);

                if (usuario == null)
                {
                    return NotFound(new { mensagem = "Usuário não encontrado" });
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuario.IdTipoUsarioNavigation.Nome),//Usa a ID para chamar o nome correspondente.
                                           //Lembrando que a tabela USUARIOS tem uma chave estrangeira que faz referência a tabela TIPO_USUARIO.
                    //new Claim(ClaimTypes.Role, usuario.IdTipoUsario.ToString())
                    //Também funcionaria, mas aí eu teria que por "1" em vez de "ADM" no Roles
                    new Claim("tipoUsuario", usuario.IdTipoUsarioNavigation.Nome) //Sem isso, não funciona no React
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("spmedgroup-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "Spmedgroup.WebApi",
                    audience: "Spmedgroup.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Deu erro!!!" });
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SOFTWARE_SP_MEDICAL_GROUP.Domains;
using SOFTWARE_SP_MEDICAL_GROUP.Interfaces;
using SOFTWARE_SP_MEDICAL_GROUP.Repositories;

namespace SOFTWARE_SP_MEDICAL_GROUP.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosMongoController : ControllerBase
    {
        private IUsuariosMongoRepository usuarioMongoRepository { get; set; }

        public UsuariosMongoController()
        {
            usuarioMongoRepository = new UsuariosMongoRepository();
        }

        [Authorize] //Por enquanto, qualquer usuário registrado no mongo pode fazer tudo. Tenho que modificar isso.
        //[Authorize(Roles = "adm")]
        [HttpPost]
        public IActionResult Cadastrar(UsuariosMongo usuario)
        {
            try
            {
                usuarioMongoRepository.Cadastrar(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(usuarioMongoRepository.ListarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        //ainda não funciona
        //[Authorize]
        //[HttpDelete("{Id}")]
        //public IActionResult Delete(string Id)
        //{
        //    try
        //    {
        //        usuarioMongoRepository.Deletar(Id);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest();
        //    }
        //}

    }

}


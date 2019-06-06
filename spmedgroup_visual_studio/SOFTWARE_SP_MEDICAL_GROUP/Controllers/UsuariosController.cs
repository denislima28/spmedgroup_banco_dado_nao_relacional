using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SOFTWARE_SP_MEDICAL_GROUP.Domains;
using SOFTWARE_SP_MEDICAL_GROUP.Interfaces;
using SOFTWARE_SP_MEDICAL_GROUP.Repositories;

namespace SOFTWARE_SP_MEDICAL_GROUP.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private IUsuarioRepository UsuarioRepository { get; set; }  //Declarando a interface.
    
        public UsuariosController() //Fazendo o construtor
        {
            UsuarioRepository = new UsuarioRepository();
        }

        [Authorize(Roles = "ADM")]
        [HttpPost]
        public IActionResult Cadastrar(Usuarios usuario)
        {
            try
            {
                using (SpmedgroupContext ctx = new SpmedgroupContext())
                {
                    UsuarioRepository.Cadastrar(usuario);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "ADM")]
        [HttpPut]
        public IActionResult Put(Usuarios usuario) 
        //Só funciona se passar todos os valores do campo no Postman.
        //Isso inclui o id do item a ser alterado
        {
            try
            {
                UsuarioRepository.Alterar(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            
        }

        [Authorize(Roles = "ADM")]
        [HttpGet]
        public IActionResult ListarUsuarios()
        {
            try
            {
                return Ok(UsuarioRepository.ListarUsuarios());
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + "Deu ruim:" });
            }
        }

        [Authorize(Roles = "ADM")]
        [HttpDelete("{Id}")] 
        //Tem que mandar a id pela URL. Sem isso, eu teria que mandar tudo no corpo.
        public IActionResult Delete(int Id)
        {
            try
            {
                UsuarioRepository.Deletar(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
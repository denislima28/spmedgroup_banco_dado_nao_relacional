using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository ConsultaRepository { get; set; }  //Declarando a interface.

        public ConsultasController() //Fazendo o construtor
        {
            ConsultaRepository = new ConsultaRepository();
        }

        
        //Controller que distingue o tipo de usuário. Qualquer usuário logado pode acessar.
        [Authorize]
        [HttpGet]
        public IActionResult ListarConsultas()
        {
            try
            {
                int idusuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                string tipousuario = (HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Role).Value);

                return Ok(ConsultaRepository.ListarConsultas(idusuario, tipousuario));
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + "ERRO" });
            }
        }

        [Authorize(Roles = "ADM")]
        [HttpPost]
        public IActionResult Cadastrar(Consultas consulta)
        {
            try
            {
                using (SpmedgroupContext ctx = new SpmedgroupContext())
                {
                    ConsultaRepository.Cadastrar(consulta);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "Medico")]
        [HttpPut]
        public IActionResult AlterarDescricao (Consultas consulta)
        {
            try
            {
                ConsultaRepository.AlterarDescricao(consulta);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "ADM")]
        [HttpPut]
        [Route("cancelamento")] //A rota seria localhost:5000/api/consultas/cancelamento
        public IActionResult Put(Consultas consulta)
        {
            try
            {
                ConsultaRepository.CancelarAgendamento(consulta);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        /*
        //Somente os administradores terão acesso a todas as consultas
        [Authorize(Roles = "ADM")]
        [HttpGet]
        public IActionResult ListarConsultas()
        {
            try
            {
                return Ok(ConsultaRepository.ListarConsultas());
            }

            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + "Deu ruim:" });
            }
        }

        //Listar as consultas de um médico
        [Authorize(Roles = "Médico")]
        [HttpGet]
        [Route("minhas")] //A rota seria localhost:5000/api/consultas/minhas
        public IActionResult ListarConsultasMedico()
        {
            try
            {
                //pegando as informações do médico
                int Id = Convert.ToInt32(HttpContext.User.Claims.First
                    (c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                //return Ok();
                return Ok(ConsultaRepository.ListarConsultasMedico(Id));
            }

            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + "Deu ruim:" });
            }
        }*/
    }
}
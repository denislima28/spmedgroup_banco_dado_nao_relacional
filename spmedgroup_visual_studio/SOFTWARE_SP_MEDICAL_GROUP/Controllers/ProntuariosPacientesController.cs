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
    public class ProntuariosPacientesController : ControllerBase
    {
        private IProntuarioPacienteRepository ProntuarioPacienteRepository { get; set; }  //Declarando a interface.

        public ProntuariosPacientesController() //Fazendo o construtor
        {
            ProntuarioPacienteRepository = new ProntuarioPacienteRepository();
        }

        [Authorize(Roles = "ADM")]
        [HttpPost]
        public IActionResult Cadastrar(ProntuariosPacientes prontuariopaciente)
        {
            try
            {
                using (SpmedgroupContext ctx = new SpmedgroupContext())
                {
                    ProntuarioPacienteRepository.Cadastrar(prontuariopaciente);
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
        public IActionResult Put(ProntuariosPacientes prontuariopaciente)
        //Só funciona se passar todos os valores do campo no Postman.
        //Isso inclui o id do item a ser alterado
        {
            try
            {
                ProntuarioPacienteRepository.Alterar(prontuariopaciente);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [Authorize(Roles = "ADM")]
        [HttpGet]
        public IActionResult ListarProntuariosPacientes()
        {
            try
            {
                return Ok(ProntuarioPacienteRepository.ListarProntuariosPacientes());
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
                ProntuarioPacienteRepository.Deletar(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
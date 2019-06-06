using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SOFTWARE_SP_MEDICAL_GROUP.Domains;
using SOFTWARE_SP_MEDICAL_GROUP.Interfaces;
using SOFTWARE_SP_MEDICAL_GROUP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOFTWARE_SP_MEDICAL_GROUP.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : Controller
    {
        private IMedicoRepository MedicoRepository { get; set; }  //Declarando a interface.

        public MedicosController() //Fazendo o construtor
        {
            MedicoRepository = new MedicoRepository();
        }

        [Authorize(Roles = "ADM")]
        [HttpPost]
        public IActionResult Cadastrar(Medicos medico)
        {
            try
            {
                using (SpmedgroupContext ctx = new SpmedgroupContext())
                {
                    MedicoRepository.Cadastrar(medico);
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
        public IActionResult Put(Medicos medico)
        //Só funciona se passar todos os valores do campo no Postman.
        //Isso inclui o id do item a ser alterado
        {
            try
            {
                MedicoRepository.Alterar(medico);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [Authorize(Roles = "ADM")]
        [HttpGet]
        public IActionResult ListarMedicos()
        {
            try
            {
                return Ok(MedicoRepository.ListarMedicos());
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
                MedicoRepository.Deletar(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}

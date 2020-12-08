using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using edital.Data;
using edital.Model;
using edital.Services;
using edital.Services.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace edital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaJuridicaController : ControllerBase
    {        
        private readonly IPessoaJuridicaService _pessoaJuridicaService;

        public PessoaJuridicaController(IPessoaJuridicaService pessoaJuridicaService)
        {
            _pessoaJuridicaService = pessoaJuridicaService;
        }

        //PUT: api/inscricoes/{id}
        [HttpPut("{id}")]
        public ActionResult<PessoaJuridica> AtualizarPessoaJuridica(int id, PessoaJuridica pessoaJuridica)
        {         
            if (id != pessoaJuridica.cnpj)
            {
                return BadRequest();
            }   
            bool resp = _pessoaJuridicaService.AtualizarPessoaJuridica(pessoaJuridica);
            if(!resp){
                return NotFound();
            }

            pessoaJuridica = _pessoaJuridicaService.GetPessoaJuridica(id);

            return pessoaJuridica;          
        }
    }
}
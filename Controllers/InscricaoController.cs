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
    public class InscricaoController : ControllerBase
    {        
        private readonly IInscricaoService _inscricaoService;

        public InscricaoController(IInscricaoService inscricaoService)
        {
            _inscricaoService = inscricaoService;
        }

        [HttpGet]
        public ActionResult<List<Inscricao>> GetInscricoes()
        {
           return _inscricaoService.GetInscricoes();
        }

        // GET: api/Inscricao/{id}
        [HttpGet("{id}")]
        public ActionResult<List<Inscricao>> GetInscricoesPessoaJuridica(int pessoajuridica_id)
        {
          return _inscricaoService.GetInscricoesPessoaJuridica(pessoajuridica_id);
        }

        //POST: api/Inscricao
        [HttpPost]
        public ActionResult<string> PostInscricao(Inscricao inscricao)
        { 
            bool resp = _inscricaoService.CadastrarInscricao(inscricao);
            if(resp){
                return "Solicitação executada com sucesso!";
            }
            else{
                return "falha ao executar a socilitação"; 
            }         
        }
    }
}
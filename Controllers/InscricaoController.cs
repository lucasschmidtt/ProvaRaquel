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
        private readonly IPessoaJuridicaService _pessoaJuridicaService;

        public InscricaoController(IInscricaoService inscricaoService, IPessoaJuridicaService pessoaJuridicaService)
        {
            _inscricaoService = inscricaoService;
            _pessoaJuridicaService = pessoaJuridicaService;
        }

        [HttpGet]
        public ActionResult<List<Inscricao>> GetInscricoes()
        {
           return _inscricaoService.GetInscricoes();
        }

        // GET: api/Inscricao/{pessoajuridica_id}
        [HttpGet("{pessoajuridica_id}/{segmento_id}")]
        public ActionResult<List<Inscricao>> GetInscricoesPessoaJuridica(int pessoajuridica_id, int segmento_id)
        {
          return _inscricaoService.GetInscricoesPessoaJuridica(pessoajuridica_id, segmento_id);
        }

        //POST: api/Inscricao
        [HttpPost]
        public ActionResult<string> PostInscricao(Inscricao inscricao)
        { 
            if (inscricao.pessoajuridica.cnpj > 0) 
            {
              _pessoaJuridicaService.GetPessoaJuridica(inscricao.pessoajuridica.cnpj);
            }
            if (inscricao.segmento.id > 0) 
            {
              _inscricaoService.GetPessoaSegmento(inscricao.segmento.id);
            }

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
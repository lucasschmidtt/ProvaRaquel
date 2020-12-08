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
        private readonly ICidadesService _cidadeService;
        private readonly IEstadosService _estadoService;

        public InscricaoController(IInscricaoService inscricaoService, IPessoaJuridicaService pessoaJuridicaService, ICidadesService cidadeService, IEstadosService estadoService)
        {
            _inscricaoService = inscricaoService;
            _pessoaJuridicaService = pessoaJuridicaService;
            _cidadeService = cidadeService;
            _estadoService = estadoService;
        }

        [HttpGet]
        public ActionResult<List<Inscricao>> GetInscricoes()
        {
           return _inscricaoService.GetInscricoes();
        }

        // GET: api/Inscricao/{pessoajuridica_id}
        [HttpGet("{pessoajuridica_id}")]
        public ActionResult<List<Inscricao>> GetInscricoesPessoaJuridica(int pessoajuridica_id)
        {
          return _inscricaoService.GetInscricoesPessoaJuridica(pessoajuridica_id);
        }

        //POST: api/Inscricao
        [HttpPost]
        public ActionResult<string> PostInscricao(Inscricao inscricao)
        { 
            if (inscricao.pessoajuridica.cnpj > 0) 
            {
              PessoaJuridica pessoajuridica = _pessoaJuridicaService.GetPessoaJuridica(inscricao.pessoajuridica.cnpj); 
              if(pessoajuridica != null){
                inscricao.pessoajuridica = pessoajuridica;
              }
            }

            if (inscricao.segmento.id > 0) 
            {
              Segmento segmento = _inscricaoService.GetPessoaSegmento(inscricao.segmento.id);
              if(segmento != null){
                inscricao.segmento = segmento;
              }
            }

            if (inscricao.pessoajuridica.endereco.cidade.estado.id > 0) 
            {
              Estado estado = _estadoService.GetEstado(inscricao.pessoajuridica.endereco.cidade.estado.id);
              if (estado != null)
              {
                inscricao.pessoajuridica.endereco.cidade.estado = estado;
              }
                
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
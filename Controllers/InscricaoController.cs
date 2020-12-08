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
        public ActionResult<string> PostInscricao(Inscricao novainscricao)
        { 
            bool resp = false;

            if(novainscricao.segmento == null || novainscricao.pessoajuridica == null)
            {
                resp = false;
            } else if (novainscricao.pessoajuridica.cnpj > 0 && novainscricao.segmento.id > 0) 
            {
                Inscricao inscricao = new Inscricao();
                
                PessoaJuridica pessoajuridica = _pessoaJuridicaService.GetPessoaJuridica(novainscricao.pessoajuridica.cnpj); 

                if(pessoajuridica != null)
                {
                    inscricao.pessoajuridica = pessoajuridica;
                } else{
                    inscricao.pessoajuridica = novainscricao.pessoajuridica;
                }

                Segmento segmento = _inscricaoService.GetPessoaSegmento(novainscricao.segmento.id);

                if(segmento != null)
                {
                    inscricao.segmento = segmento;
                } else{
                    inscricao.segmento = novainscricao.segmento;
                }

                Estado estado = _estadoService.GetEstado(novainscricao.pessoajuridica.endereco.cidade.estado.id);
        
                if (estado != null)
                {
                    inscricao.pessoajuridica.endereco.cidade.estado = estado;
                } else {
                    inscricao.pessoajuridica.endereco.cidade.estado.id = 0;
                }

                Cidade cidade = _cidadeService.GetCidade(novainscricao.pessoajuridica.endereco.cidade.id);
        
                if (cidade != null)
                {
                    inscricao.pessoajuridica.endereco.cidade = cidade;
                } else {
                    inscricao.pessoajuridica.endereco.cidade.id = 0;
                }

                resp = _inscricaoService.CadastrarInscricao(inscricao);        
            } else 
            {
                resp = _inscricaoService.CadastrarInscricao(novainscricao);            
            }

            if(resp){
                return "Solicitação executada com sucesso!";
            }
            else{
                return "falha ao executar a socilitação"; 
            }         

        }
    }
}
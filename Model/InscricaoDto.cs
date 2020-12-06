using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace edital.Model
{
    public sealed class InscricaoDTO: IActionResult
    {
        public InscricaoDTO()
        {}
        public InscricaoDTO(Inscricao inscricao)
        {
            pessoajuridica_id = inscricao.pessoajuridica_id; 
            segmento_id = inscricao.segmento_id;
            pessoajuridica = inscricao.pessoajuridica;
            segmento = inscricao.segmento; 
            flgativo = inscricao.flgativo; 
            nomeiniciativa = inscricao.nomeiniciativa; 
            objetivos = inscricao.objetivos; 
            publicoalvo = inscricao.publicoalvo;
        }
        public int pessoajuridica_id {get; set;}
        public int segmento_id {get; set;}
        public PessoaJuridica pessoajuridica { get; set; }
        public Segmento segmento { get; set; }
        public bool flgativo { get; set; }
        public string nomeiniciativa { get; set; }
        public string objetivos { get; set; }
        public string publicoalvo { get; set; }
        
        public Inscricao MapTo(Inscricao inscricao)
        {
            inscricao.pessoajuridica = pessoajuridica;
            inscricao.segmento = segmento;
            inscricao.flgativo = flgativo;
            inscricao.nomeiniciativa = nomeiniciativa;
            inscricao.objetivos = objetivos;
            inscricao.publicoalvo = publicoalvo;

            return inscricao;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new JsonResult(this).ExecuteResultAsync(context);
        }
        
    }
}
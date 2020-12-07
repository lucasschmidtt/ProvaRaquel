using System;
using System.ComponentModel.DataAnnotations;

namespace edital.Model
{
    public class Inscricao 
    {
        public Inscricao() 
        {
        }
        public Inscricao(PessoaJuridica pessoajuridica) 
        {
          this.pessoajuridica = pessoajuridica;
        }
        public Inscricao(PessoaJuridica pessoajuridica, Segmento segmento) 
        {
          this.pessoajuridica = pessoajuridica;
          this.segmento = segmento;
        }
        public Inscricao(PessoaJuridica pessoajuridica, Segmento segmento, bool flativo) 
        {
          this.pessoajuridica = pessoajuridica;
          this.segmento = segmento;
          this.flgativo = flativo;
        }
        public Inscricao(PessoaJuridica pessoajuridica, Segmento segmento, bool flgativo, string nomeiniciativa) 
        {
          this.pessoajuridica = pessoajuridica;
          this.segmento = segmento;
          this.flgativo = flgativo;
          this.nomeiniciativa = nomeiniciativa;
        }
        public Inscricao(PessoaJuridica pessoajuridica, Segmento segmento, bool flgativo, string nomeiniciativa, string objetivos) 
        {
          this.pessoajuridica = pessoajuridica;
          this.segmento = segmento;
          this.flgativo = flgativo;
          this.nomeiniciativa = nomeiniciativa;
          this.objetivos = objetivos;
        }
        public Inscricao(PessoaJuridica pessoajuridica, Segmento segmento, bool flgativo, string nomeiniciativa, string objetivos, string publicoalvo) 
        {
          this.pessoajuridica = pessoajuridica;
          this.segmento = segmento;
          this.flgativo = flgativo;
          this.nomeiniciativa = nomeiniciativa;
          this.objetivos = objetivos;
          this.publicoalvo = publicoalvo;
        }
    
        [Required]
        public int pessoajuridica_id { get; set; }

        [Required]
        public int segmento_id { get; set; }
        [Required]
        public PessoaJuridica pessoajuridica { get; set; }
        [Required]
        public Segmento segmento { get; set; }
        [Required]
        public bool flgativo { get; set; }
        public string nomeiniciativa { get; set; }
        public string objetivos { get; set; }
        public string publicoalvo { get; set; }

    }
}
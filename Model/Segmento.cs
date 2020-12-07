using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace edital.Model
{
    public class Segmento
    {
      public Segmento()
      {}

      public Segmento(int id, string segmento, string descricao, Edital edital, List<Inscricao> inscricoes)
      {
        this.id = id;
        this.segmento = segmento;
        this.descricao = descricao;
        this.edital = edital;
        this.inscricoes = inscricoes;
      }
        [Key]
        public int id { get; set; }
        [Required]
        public string segmento { get; set; }
        public string descricao { get; set; }   
        [Required]     
        public Edital edital { get; set; }
        public List<Inscricao> inscricoes { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace edital.Model
{
    public class Edital
    {
    public Edital()
    {
    }

    public Edital(int id, string nome, DateTime datainicio, DateTime? datafim, int vigencia, List<Segmento> segmentos)
    {
      this.id = id;
      this.nome = nome;
      this.datainicio = datainicio;
      this.datafim = datafim;
      this.vigencia = vigencia;
      this.segmentos = segmentos;
    }

    [Key]
        public int id { get; set; }
        [Required]
        public string nome { get; set; }
        [Required]
        public DateTime datainicio { get; set; }

        public DateTime? datafim { get; set; }
        [Required]
        public int vigencia { get; set; }

        public List<Segmento> segmentos { get; set; }
    }    
}
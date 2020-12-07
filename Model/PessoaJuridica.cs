using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace edital.Model
{
    public class PessoaJuridica
    {
      public PessoaJuridica() 
      {}

      public PessoaJuridica(Endereco endereco)
      {
        this.endereco = endereco;
        this.representante = new Representante();
        this.contato = new Contato();
        this.inscricoes = new List<Inscricao>();
      }
      public PessoaJuridica(Endereco endereco, Representante representante)
      {
        this.endereco = endereco;
        this.representante = representante;
        this.contato = new Contato();
        this.inscricoes = new List<Inscricao>();
      }
      public PessoaJuridica(Endereco endereco, Representante representante, Contato contato)
      {
        this.endereco = endereco;
        this.representante = representante;
        this.contato = contato;
        this.inscricoes = new List<Inscricao>();
      }
      public PessoaJuridica(Endereco endereco, Representante representante, Contato contato, List<Inscricao> inscricoes)
      {
        this.endereco = endereco;
        this.representante = representante;
        this.contato = contato;
        this.inscricoes = inscricoes;
      }
      public PessoaJuridica(Endereco endereco, Representante representante, Contato contato, List<Inscricao> inscricoes, string razaosocial)
      {
        this.endereco = endereco;
        this.representante = representante;
        this.contato = contato;
        this.inscricoes = inscricoes;
        this.razaosocial = razaosocial;
      }
        [Key]
        public int cnpj { get; set; }
        [Required]
        public string razaosocial { get; set; }
        [Required]
        public Endereco endereco { get; set; }
        [Required]
        public Representante representante { get; set; }
        [Required]
        public Contato contato { get; set; }
        List<Inscricao> inscricoes { get; set; }
    }
}
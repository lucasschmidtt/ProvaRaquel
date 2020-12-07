using System.ComponentModel.DataAnnotations;

namespace edital.Model
{
    public class Contato
    {
    public Contato()
    {
    }

    public Contato(int id, string telefone, string email, string celular, string site)
    {
      this.id = id;
      this.telefone = telefone;
      this.email = email;
      this.celular = celular;
      this.site = site;
    }

    [Key]
        [Required]
        public int id { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        [Required]
        public string celular { get; set; }
        public string site { get; set; } 
    }
}
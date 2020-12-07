using System.ComponentModel.DataAnnotations;

namespace edital.Model
{
    public class Anexo
    {
    public Anexo()
    {
    }

    public Anexo(int id, string nome, string contentype, byte[] arquivo)
    {
      this.id = id;
      this.nome = nome;
      this.contentype = contentype;
      this.arquivo = arquivo;
    }

    [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string contentype { get; set; }
        public byte[] arquivo { get; set; } 
       
    }
}
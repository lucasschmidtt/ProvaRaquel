using System.Linq;
using edital.Data;
using edital.Model;
using edital.Services.Interfaces;
using System;
using Microsoft.EntityFrameworkCore;

namespace edital.Services
{
    public class PessoaJuridicaService: IPessoaJuridicaService
    {
        private readonly ApplicationDbContext _context;
        
        public PessoaJuridicaService(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public bool AtualizarPessoaJuridica(PessoaJuridica pessoaJuridica)
        {
            try{
                _context.pessoajuridica.Update(pessoaJuridica);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex){
                Console.WriteLine(ex);
                return false;
            } 
        }

        public PessoaJuridica GetPessoaJuridica(int cnpj)
        {
            PessoaJuridica pessoajuridica = _context.pessoajuridica.Include(i => i.endereco).Include(i => i.representante).Include(i => i.contato).SingleOrDefault(e => e.cnpj == cnpj);
            return pessoajuridica;

        }
    }
}
using System.Linq;
using System.Collections.Generic;
using edital.Data;
using edital.Model;
using edital.Services.Interfaces;
using System;
using Microsoft.EntityFrameworkCore;

namespace edital.Services
{
  public class InscricaoService : IInscricaoService
  {
      private readonly ApplicationDbContext _context;
          
          public InscricaoService(ApplicationDbContext context)
          {
              _context = context;
          }
      public bool CadastrarInscricao(Inscricao inscricao)
      {
          bool resp = true;
          try {
              _context.inscricao.Add(inscricao);  
              _context.SaveChanges();
          } catch {
              resp = false;
          }
          return resp;
      }

      public List<Inscricao> GetInscricoesPessoaJuridica(int pessoajuridica_id, int segmento_id)
      {
          return _context.inscricao.Include(i => i.pessoajuridica).Include(i => i.segmento_id)
            .Where(e => e.pessoajuridica_id == pessoajuridica_id)
            .ToList();
      }

      public List<Inscricao> GetInscricoes()
      {
          List<Inscricao> inscricoes = new List<Inscricao>();

          inscricoes = _context.inscricao.Include(i => i.pessoajuridica).ToList();
          return inscricoes;
      }

      public bool GetPessoaSegmento(int id)
      {
          Segmento segmento = _context.segmento.SingleOrDefault(e => e.id == id);
          if(segmento == null)
          {
            return false;
          } else {
            _context.segmento.Update(segmento);
            _context.SaveChanges();
            return true;
          }

      }
  }
}
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
          } catch(Exception ex) {
              resp = false;
              Console.WriteLine(ex);
            }
          return resp;
      }

      public List<Inscricao> GetInscricoesPessoaJuridica(int pessoajuridica_id)
      {
          return _context.inscricao.Include(i => i.pessoajuridica)
            .Where(e => e.pessoajuridica_id == pessoajuridica_id)
            .ToList();
      }

      public List<Inscricao> GetInscricoes()
      {
          List<Inscricao> inscricoes = new List<Inscricao>();

          inscricoes = _context.inscricao.Include(i => i.pessoajuridica).ToList();
          return inscricoes;
      }

      public Segmento GetPessoaSegmento(int id)
      {
          Segmento segmento = _context.segmento.Include(i => i.edital).SingleOrDefault(e => e.id == id);
          return segmento;
      }
      public Representante GetRepresentante(int id)
      {
          Representante representante = _context.representante.Include(i => i.contato).Include(i => i.endereco).SingleOrDefault(e => e.id == id);
          return representante;
      }
  }
}
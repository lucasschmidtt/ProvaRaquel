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
              /* var i = inscricao.MapTo(new Inscricao
              {
                  pessoajuridica_id = inscricao.pessoajuridica.cnpj,
                  segmento_id = inscricao.segmento.id,
                  pessoajuridica = inscricao.pessoajuridica,
                  segmento = inscricao.segmento,
                  flgativo = inscricao.flgativo,
                  nomeiniciativa = inscricao.nomeiniciativa,
                  objetivos = inscricao.objetivos,
                  publicoalvo = inscricao.publicoalvo,
              });  */
              _context.inscricao.Add(inscricao);  
              _context.SaveChanges();
          } catch {
              resp = false;
          }
          return resp;
      }

      public List<Inscricao> GetInscricoesPessoaJuridica(int pessoajuridica_id)
      {
          return _context.inscricao
            .Where(e => e.pessoajuridica_id == pessoajuridica_id)
            .ToList();
      }

      public List<Inscricao> GetInscricoes()
      {
          List<Inscricao> inscricoes = new List<Inscricao>();

          inscricoes = _context.inscricao.ToList();
          return inscricoes;
      }
  }
}
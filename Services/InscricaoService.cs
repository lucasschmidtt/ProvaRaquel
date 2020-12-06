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
      /* public async Task<ActionResult> CadastrarInscricao(InscricaoDTO inscricao)
      {
            //bool resp = true;
            var i = inscricao.MapTo(new Inscricao
            {
                pessoajuridica_id = inscricao.pessoajuridica.cnpj,
                segmento_id = inscricao.segmento.id,
                pessoajuridica = inscricao.pessoajuridica,
                segmento = inscricao.segmento,
                flgativo = inscricao.flgativo,
                nomeiniciativa = inscricao.nomeiniciativa,
                objetivos = inscricao.objetivos,
                publicoalvo = inscricao.publicoalvo,
            }
            );
            try
            {
                //int cnpj = inscricao.pessoajuridica.cnpj;
                _context.inscricao.Add(i);
                // _context.segmento.Add(inscricao.segmento);
                // _context.edital.Add(inscricao.segmento.edital);
                //_context.pessoajuridica.Add(inscricao.pessoajuridica);
                // _context.representante.Add(inscricao.pessoajuridica.representante);
                // _context.endereco.Add(inscricao.pessoajuridica.endereco);
                // _context.cidade.Add(inscricao.pessoajuridica.endereco.cidade);
                // _context.estado.Add(inscricao.pessoajuridica.endereco.cidade.estado);
                // _context.contato.Add(inscricao.pessoajuridica.contato);
                // _context.endereco.Add(inscricao.pessoajuridica.endereco);
                return await _context.SaveChangesAsync();
            } catch (Exception ex){
                Console.WriteLine(ex);
                return null;
            }
            //return resp;
            } */

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
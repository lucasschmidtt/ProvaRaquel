using System.Collections.Generic;
using edital.Model;

namespace edital.Services.Interfaces
{
    public interface IInscricaoService
    {
        List<Inscricao> GetInscricoes();
        List<Inscricao> GetInscricoesPessoaJuridica(int pessoajuridica_id);
        bool CadastrarInscricao(Inscricao Inscricao);    
        Segmento GetPessoaSegmento(int id);    
        Representante GetRepresentante(int id);    
    }
}
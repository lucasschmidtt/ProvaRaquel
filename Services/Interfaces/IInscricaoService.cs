using System.Collections.Generic;
using edital.Model;

namespace edital.Services.Interfaces
{
    public interface IInscricaoService
    {
        // retornar todas as incricoes
        List<Inscricao> GetInscricoes();
        // retornar a inscricoes/inscricao de uma pessoa juridica
        List<Inscricao> GetInscricoesPessoaJuridica(int pessoajuridica_id);
        // cadastrar uma inscricao de uma pessoa juridica
        bool CadastrarInscricao(Inscricao Inscricao);    
    }
}
using System.Collections.Generic;
using edital.Model;

namespace edital.Services.Interfaces
{
    public interface IPessoaJuridicaService
    {
        // atualizar dados de uma pessoa juridica cadastrada
        bool AtualizarPessoaJuridica(PessoaJuridica pessoaJuridica);
    }
}
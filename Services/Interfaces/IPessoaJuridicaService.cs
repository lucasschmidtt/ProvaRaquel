using System.Collections.Generic;
using edital.Model;

namespace edital.Services.Interfaces
{
    public interface IPessoaJuridicaService
    {
        bool AtualizarPessoaJuridica(PessoaJuridica pessoaJuridica);
        PessoaJuridica GetPessoaJuridica(int cnpj);
    }
}
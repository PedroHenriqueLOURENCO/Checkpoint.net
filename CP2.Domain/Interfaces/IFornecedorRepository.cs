using CP2.Domain.Entities;
using System.Collections.Generic;

namespace CP2.Domain.Interfaces
{
    public interface IFornecedorRepository
    {
        FornecedorEntity SalvarDados(FornecedorEntity fornecedor);
        FornecedorEntity EditarDados(int id, FornecedorEntity fornecedor);
        FornecedorEntity? ObterPorId(int id);
        IEnumerable<FornecedorEntity> ObterTodos();
        FornecedorEntity? DeletarDados(int id);
    }
}

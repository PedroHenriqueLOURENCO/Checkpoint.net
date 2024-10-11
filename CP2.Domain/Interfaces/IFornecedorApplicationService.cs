using CP2.Domain.Entities;
using CP2.Domain.Interfaces.Dtos;
using System.Collections.Generic;

namespace CP2.Domain.Interfaces
{
    public interface IFornecedorApplicationService
    {
        FornecedorEntity SalvarDadosFornecedor(IFornecedorDto fornecedorDto);
        FornecedorEntity EditarDadosFornecedor(int id, IFornecedorDto fornecedorDto);
        FornecedorEntity? ObterFornecedorPorId(int id);
        IEnumerable<FornecedorEntity> ObterTodosFornecedores();
        FornecedorEntity? DeletarDadosFornecedor(int id);
    }
}

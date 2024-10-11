using CP2.Domain.Entities;
using System.Collections.Generic;

namespace CP2.Domain.Interfaces
{
    public interface IVendedorRepository
    {
        VendedorEntity SalvarDados(VendedorEntity vendedor);
        VendedorEntity EditarDados(int id, VendedorEntity vendedor);
        VendedorEntity? ObterPorId(int id);
        IEnumerable<VendedorEntity> ObterTodos();
        VendedorEntity? DeletarDados(int id);
    }
}

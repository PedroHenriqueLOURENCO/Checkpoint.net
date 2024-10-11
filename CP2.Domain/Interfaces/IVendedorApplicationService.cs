using CP2.Domain.Entities;
using CP2.Domain.Interfaces.Dtos;
using System.Collections.Generic;

namespace CP2.Domain.Interfaces
{
    public interface IVendedorApplicationService
    {
        VendedorEntity SalvarDadosVendedor(IVendedorDto vendedorDto);
        VendedorEntity EditarDadosVendedor(int id, IVendedorDto vendedorDto);
        VendedorEntity? ObterVendedorPorId(int id);
        IEnumerable<VendedorEntity> ObterTodosVendedores();
        VendedorEntity? DeletarDadosVendedor(int id);
    }
}

using CP2.Data.AppData;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CP2.Data.Repositories
{
    public class VendedorRepository : IVendedorRepository
    {
        private readonly ApplicationContext _context;

        public VendedorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public VendedorEntity SalvarDados(VendedorEntity vendedor)
        {
            _context.Vendedores.Add(vendedor);
            _context.SaveChanges();
            return vendedor;
        }

        public VendedorEntity EditarDados(int id, VendedorEntity vendedor)
        {
            var existingVendedor = _context.Vendedores.Find(id);
            if (existingVendedor != null)
            {
                // atualiza
                existingVendedor.Nome = vendedor.Nome;
                existingVendedor.Email = vendedor.Email;
                existingVendedor.Telefone = vendedor.Telefone;
                existingVendedor.DataNascimento = vendedor.DataNascimento;
                existingVendedor.Endereco = vendedor.Endereco;
                existingVendedor.DataContratacao = vendedor.DataContratacao;
                existingVendedor.ComissaoPercentual = vendedor.ComissaoPercentual;
                existingVendedor.MetaMensal = vendedor.MetaMensal;
                
                _context.SaveChanges();
            }
            return existingVendedor;
        }

        public VendedorEntity? ObterPorId(int id)
        {
            return _context.Vendedores.Find(id);
        }

        public IEnumerable<VendedorEntity> ObterTodos()
        {
            return _context.Vendedores.ToList();
        }

        public VendedorEntity? DeletarDados(int id)
        {
            var vendedor = _context.Vendedores.Find(id);
            if (vendedor != null)
            {
                _context.Vendedores.Remove(vendedor);
                _context.SaveChanges();
            }
            return vendedor;
        }
    }
}

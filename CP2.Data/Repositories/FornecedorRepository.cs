using CP2.Data.AppData;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CP2.Data.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly ApplicationContext _context;

        public FornecedorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public FornecedorEntity SalvarDados(FornecedorEntity fornecedor)
        {
            _context.Fornecedores.Add(fornecedor);
            _context.SaveChanges();
            return fornecedor;
        }

        public FornecedorEntity EditarDados(int id, FornecedorEntity fornecedor)
        {
            var existingFornecedor = _context.Fornecedores.Find(id);
            if (existingFornecedor != null)
            {
                // atualiza... 
                existingFornecedor.Nome = fornecedor.Nome;
                // atualizar...
                _context.SaveChanges();
            }
            return existingFornecedor;
        }

        public FornecedorEntity? ObterPorId(int id)
        {
            return _context.Fornecedores.Find(id);
        }

        public IEnumerable<FornecedorEntity> ObterTodos()
        {
            return _context.Fornecedores.ToList();
        }

        public FornecedorEntity? DeletarDados(int id)
        {
            var fornecedor = _context.Fornecedores.Find(id);
            if (fornecedor != null)
            {
                _context.Fornecedores.Remove(fornecedor);
                _context.SaveChanges();
            }
            return fornecedor;
        }
    }
}

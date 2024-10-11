using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using CP2.Domain.Interfaces.Dtos;
using System.Collections.Generic;

namespace CP2.Application.Services
{
    public class FornecedorApplicationService : IFornecedorApplicationService
    {
        private readonly IFornecedorRepository _repository;

        public FornecedorApplicationService(IFornecedorRepository repository)
        {
            _repository = repository;
        }

        public FornecedorEntity SalvarDadosFornecedor(IFornecedorDto fornecedorDto)
        {
            fornecedorDto.Validate();

            var fornecedorEntity = new FornecedorEntity
            {
                Nome = fornecedorDto.Nome,
                CNPJ = fornecedorDto.CNPJ,
                Endereco = fornecedorDto.Endereco,
                Telefone = fornecedorDto.Telefone,
                Email = fornecedorDto.Email,
                CriadoEm = DateTime.Now
            };

            return _repository.SalvarDados(fornecedorEntity);
        }

        public FornecedorEntity EditarDadosFornecedor(int id, IFornecedorDto fornecedorDto)
        {
            fornecedorDto.Validate();

            var fornecedorEntity = new FornecedorEntity
            {
                Nome = fornecedorDto.Nome,
                CNPJ = fornecedorDto.CNPJ,
                Endereco = fornecedorDto.Endereco,
                Telefone = fornecedorDto.Telefone,
                Email = fornecedorDto.Email
            };

            return _repository.EditarDados(id, fornecedorEntity);
        }

        public FornecedorEntity? ObterFornecedorPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public IEnumerable<FornecedorEntity> ObterTodosFornecedores()
        {
            return _repository.ObterTodos();
        }

        public FornecedorEntity? DeletarDadosFornecedor(int id)
        {
            return _repository.DeletarDados(id);
        }
    }
}

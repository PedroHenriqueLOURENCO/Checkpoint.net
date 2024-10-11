using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using CP2.Domain.Interfaces.Dtos;
using System.Collections.Generic;

namespace CP2.Application.Services
{
    public class VendedorApplicationService : IVendedorApplicationService
    {
        private readonly IVendedorRepository _repository;

        public VendedorApplicationService(IVendedorRepository repository)
        {
            _repository = repository;
        }

        public VendedorEntity SalvarDadosVendedor(IVendedorDto vendedorDto)
        {
            vendedorDto.Validate();

            var vendedorEntity = new VendedorEntity
            {
                Nome = vendedorDto.Nome,
                Email = vendedorDto.Email,
                Telefone = vendedorDto.Telefone,
                DataNascimento = vendedorDto.DataNascimento,
                Endereco = vendedorDto.Endereco,
                DataContratacao = vendedorDto.DataContratacao,
                ComissaoPercentual = vendedorDto.ComissaoPercentual,
                MetaMensal = vendedorDto.MetaMensal,
                CriadoEm = DateTime.Now
            };

            return _repository.SalvarDados(vendedorEntity);
        }

        public VendedorEntity EditarDadosVendedor(int id, IVendedorDto vendedorDto)
        {
            vendedorDto.Validate();

            var vendedorEntity = new VendedorEntity
            {
                Nome = vendedorDto.Nome,
                Email = vendedorDto.Email,
                Telefone = vendedorDto.Telefone,
                DataNascimento = vendedorDto.DataNascimento,
                Endereco = vendedorDto.Endereco,
                DataContratacao = vendedorDto.DataContratacao,
                ComissaoPercentual = vendedorDto.ComissaoPercentual,
                MetaMensal = vendedorDto.MetaMensal
            };

            return _repository.EditarDados(id, vendedorEntity);
        }

        public VendedorEntity? ObterVendedorPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public IEnumerable<VendedorEntity> ObterTodosVendedores()
        {
            return _repository.ObterTodos();
        }

        public VendedorEntity? DeletarDadosVendedor(int id)
        {
            return _repository.DeletarDados(id);
        }
    }
}

using System;

namespace CP2.Domain.Interfaces.Dtos
{
    public interface IVendedorDto
    {
        string Nome { get; set; }
        string Email { get; set; }
        string Telefone { get; set; }
        DateTime DataNascimento { get; set; }
        string Endereco { get; set; }
        DateTime DataContratacao { get; set; }
        decimal ComissaoPercentual { get; set; }
        decimal MetaMensal { get; set; }

        void Validate();
    }
}

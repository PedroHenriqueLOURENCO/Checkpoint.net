using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CP2.Domain.Entities
{
    [Table("tb_vendedor")]
    public class VendedorEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(15)]
        public string Telefone { get; set; }

        public DateTime DataNascimento { get; set; }

        [MaxLength(200)]
        public string Endereco { get; set; }

        public DateTime DataContratacao { get; set; }

        [Column(TypeName = "decimal(5, 2)")] // Por exemplo, 999.99
        public decimal ComissaoPercentual { get; set; }

        [Column(TypeName = "decimal(10, 2)")] // Por exemplo, 99999999.99
        public decimal MetaMensal { get; set; }

        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }
}

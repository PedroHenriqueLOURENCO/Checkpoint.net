using CP2.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CP2.Data.AppData
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<FornecedorEntity> Fornecedores { get; set; }
        public DbSet<VendedorEntity> Vendedores { get; set; }
    }
}

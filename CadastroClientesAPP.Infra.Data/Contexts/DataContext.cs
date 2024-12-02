using CadastroClientesAPP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CadastroClientesAPP.Infra.Data.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
    }
}

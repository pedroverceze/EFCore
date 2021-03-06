using Curso.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Logging;
using PedidoConsole.Domain;

namespace Curso.Data
{
    public class ApplicationContext : DbContext
    {
        private static readonly ILoggerFactory _logger = LoggerFactory.Create(p => p.AddConsole());

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_logger)
            .EnableSensitiveDataLogging()
            .UseSqlServer("Data Source=localhost;User Id=sa;Password=Pedro123;Initial Catalog=CursoEFCore;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new ClienteMapper());
            builder.ApplyConfiguration(new ProdutoMapper());
            builder.ApplyConfiguration(new PedidoMapper());
            builder.ApplyConfiguration(new PedidoItemMapper());

            /*
            Caso queira utilizar essa configuração, o EF varre o assembly e mapeia todas as classes concretas que implementam
            a interface IEntityTypeConfiguration. Estou passando a propria classe pois só temos esse projeto.

            
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
            */
        }
    }
}
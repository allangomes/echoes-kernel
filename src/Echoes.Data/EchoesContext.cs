using Auxo.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace Echoes.Data
{
    public class EchoesContext : DataContext
    {
        public EchoesContext() : base(new DbContextOptionsBuilder<EchoesContext>()
            .UseNpgsql("Server=localhost;port=5432;Database=EchoesTest;Username=;Password=").Options)
        {
        }

        public EchoesContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");
            base.OnModelCreating(modelBuilder);
        }
    }
}
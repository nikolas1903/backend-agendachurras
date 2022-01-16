using Data.Mapping;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<UsuarioEntity> Usuario { get; set; }
        public DbSet<ChurrascoEntity> Churrasco { get; set; }
        public DbSet<ChurrascoUsuarioEntity> ChurrascoUsuario { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base (options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UsuarioEntity>(new UsuarioMapping().Configure);
            modelBuilder.Entity<ChurrascoEntity>(new ChurrascoMapping().Configure);
            modelBuilder.Entity<ChurrascoUsuarioEntity>(new ChurrascoUsuarioMapping().Configure);
        }
    }
}
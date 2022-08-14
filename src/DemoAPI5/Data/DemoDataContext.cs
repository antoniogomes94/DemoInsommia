using DemoAPI5.Data.Mappings;
using DemoAPI5.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI5.Data
{
    public class DemoDataContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        public DemoDataContext(DbContextOptions<DemoDataContext> options)
        : base(options){ }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite("DataSource=demo.db;Cache=Shared");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<Usuario>(new UsuarioMap());
            modelBuilder.ApplyConfiguration<Cliente>(new ClienteMap());
        }
    }
}

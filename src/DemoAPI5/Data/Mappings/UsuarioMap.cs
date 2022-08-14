using DemoAPI5.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoAPI5.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            // Tabela
            builder.ToTable("Usuario");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
               .ValueGeneratedOnAdd();

            // Propriedades
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Senha)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);
             
            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Admin)
                .IsRequired(false)
                .HasDefaultValue(false);

            builder.Property(x => x.DataCriacao);
        }
    }
}


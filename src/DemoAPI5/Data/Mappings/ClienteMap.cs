using DemoAPI5.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoAPI5.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            // Tabela
            builder.ToTable("Cliente");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            // Propriedades
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.CPF)
              .IsRequired()
              .HasColumnType("NVARCHAR")
              .HasMaxLength(14);

            builder.Property(x => x.Senha)
              .IsRequired()
              .HasColumnType("NVARCHAR")
              .HasMaxLength(50);

            builder.Property(x => x.DataCriacao);
        }
    }
}

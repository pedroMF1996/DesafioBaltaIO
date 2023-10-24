using DesafioBaltaIO.Domain.IBGE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioBaltaIO.Data.IBGE.Mapping
{
    public class LocalidadeMapping : IEntityTypeConfiguration<LocalidadeModel>
    {
        public void Configure(EntityTypeBuilder<LocalidadeModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnType("uniqueidentifier");

            builder.Property(x => x.Codigo)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(7);

            builder.Property(x => x.Estado)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(2);

            builder.Property(x => x.Cidade)
                .IsRequired()
                .HasColumnType("nvarchar(160)");

            builder.Property(x => x.CadastradoPor)
                .HasColumnType("nvarchar")
                .HasDefaultValue(Guid.Empty);

            builder.Property(x => x.EditadoPor)
                .HasColumnType("nvarchar")
                .HasDefaultValue(Guid.Empty);

            builder.Property(x => x.DataCadastro)
                .HasColumnType("date")
                .HasDefaultValue(DateTime.MinValue);

            builder.Property(x => x.DataEdicao)
                .HasColumnType("date")
                .HasDefaultValue(DateTime.MinValue);

            builder.ToTable("Localidades");
        }
    }
}

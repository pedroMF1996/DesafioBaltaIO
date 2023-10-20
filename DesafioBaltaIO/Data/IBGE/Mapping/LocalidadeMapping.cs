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
            
            builder.Property(x => x.Codigo)
                .IsRequired()
                .HasMaxLength(7);

            builder.Property(x => x.Estado) 
                .IsRequired() 
                .HasMaxLength(2);

            builder.Property(x => x.Cidade)
                .IsRequired();

            builder.Property(x => x.CadastradoPor)
                .IsRequired()
                .HasDefaultValue(Guid.Empty);

            builder.ToTable("Localidades");
        }
    }
}

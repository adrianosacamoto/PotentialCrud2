using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PotentialCrud2.Domain.Entities;

namespace PotentialCrud2.Data.Mapping
{
    public class DesenvolvedorMap : IEntityTypeConfiguration<DesenvolvedorEntity>
    {
        public void Configure(EntityTypeBuilder<DesenvolvedorEntity> builder)
        {
            builder.ToTable("Desenvolvedor");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Nome)
                   .IsRequired()
                   .HasMaxLength(60);
        }
    }
}

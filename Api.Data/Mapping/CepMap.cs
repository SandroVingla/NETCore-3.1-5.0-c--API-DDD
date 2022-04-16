using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Mapping
{
  public class CepMap : IEntityTypeConfiguration<CepEntity>
  {
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CepEntity> builder)
    {
      builder.ToTable("Cep");
      builder.HasKey(u => u.Id);
      builder.HasIndex(u => u.Cep);
      builder.HasOne(c => c.Municipio)
             .WithMany(m => m.Ceps);
      
    }
  }
}

using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Mapping
{
  public class MunicipioMap : IEntityTypeConfiguration<MunicipioEntity>
  {
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<MunicipioEntity> builder)
    {
      builder.ToTable("Municipio");
      builder.HasKey(u => u.Id);
      builder.HasIndex(u => u.CodIBGE);
      builder.HasOne(u => u.Uf)
             .WithMany(m => m.Municipios);
      
    }
  }
}

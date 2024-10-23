using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class LugarMap : IEntityTypeConfiguration<LugarModel>
    {
        public void Configure(EntityTypeBuilder<LugarModel> builder)
        {
            builder.HasKey(x => x.LugarId);
            builder.Property(x => x.Foto).IsRequired().HasMaxLength(255);
            builder.Property(x => x.EndereçoLugar).IsRequired().HasMaxLength(255);
            builder.Property(x => x.DetalhesLugar).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ObjetivoLugar).IsRequired().HasMaxLength(255);
        }
    }
}

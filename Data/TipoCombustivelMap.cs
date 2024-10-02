using Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class TipoCombustivelMap : IEntityTypeConfiguration<TipoCombustivelModel>
    {
        public void Configure(EntityTypeBuilder<TipoCombustivelModel> builder)
        {
            builder.HasKey(x => x.TipoCombustivelId);
            builder.Property(x => x.Combustivel).IsRequired().HasMaxLength(255);

        }
    }
}

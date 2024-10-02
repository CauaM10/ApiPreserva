using Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class ConsumoMap : IEntityTypeConfiguration<ConsumoModel>
    {
        public void Configure(EntityTypeBuilder<ConsumoModel> builder)
        {
            builder.HasKey(x => x.ConsumoId);
            builder.Property(x => x.ConsumoKm).IsRequired().HasMaxLength(255);
   
        }
    }
}
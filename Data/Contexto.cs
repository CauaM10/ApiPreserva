using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<CadastroEmpresaModel> Cadastro { get; set; }

        public DbSet<TipoCombustivelModel> TipoCombustivel { get; set; }

        public DbSet<MotoristaModel> Motorista { get; set; }

        public DbSet<VeiculoModel> Veiculo { get; set; }

        public DbSet<ConsumoModel> Consumo { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CadastroEmpresaMap());
            modelBuilder.ApplyConfiguration(new TipoCombustivelMap());
            modelBuilder.ApplyConfiguration(new MotoristaMap());
            modelBuilder.ApplyConfiguration(new VeiculoMap());
            modelBuilder.ApplyConfiguration(new ConsumoMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}

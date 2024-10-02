using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class ConsumoRepositorio : IConsumoRepositorio
    {
        private readonly Contexto _dbContext;

        public ConsumoRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ConsumoModel>> GetAll()
        {
            return await _dbContext.Consumo.ToListAsync();
        }

        public async Task<ConsumoModel> GetById(int id)
        {
            return await _dbContext.Consumo.FirstOrDefaultAsync(x => x.ConsumoId == id);
        }

        public async Task<ConsumoModel> InsertConsumo(ConsumoModel consumo)
        {
            await _dbContext.Consumo.AddAsync(consumo);
            await _dbContext.SaveChangesAsync();
            return consumo;
        }

        public async Task<ConsumoModel> UpdateConsumo(ConsumoModel consumo, int id)
        {
            ConsumoModel consumos = await GetById(id);
            if (consumos == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                consumos.ConsumoKm = consumo.ConsumoKm;

                _dbContext.Consumo.Update(consumos);
                await _dbContext.SaveChangesAsync();
            }
            return consumos;

        }

        public async Task<bool> DeleteConsumo(int id)
        {
            ConsumoModel consumos = await GetById(id);
            if (consumos == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Consumo.Remove(consumos);
            await _dbContext.SaveChangesAsync();
            return true;
        }


    }
}
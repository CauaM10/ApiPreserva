using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class TipoCombustivelRepositorio : ITipoCombustivelRepositorio
    {
        private readonly Contexto _dbContext;

        public TipoCombustivelRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TipoCombustivelModel>> GetAll()
        {
            return await _dbContext.TipoCombustivel.ToListAsync();
        }

        public async Task<TipoCombustivelModel> GetById(int id)
        {
            return await _dbContext.TipoCombustivel.FirstOrDefaultAsync(x => x.TipoCombustivelId == id);
        }

        public async Task<TipoCombustivelModel> InsertCombustivel(TipoCombustivelModel combustivel)
        {
            await _dbContext.TipoCombustivel.AddAsync(combustivel);
            await _dbContext.SaveChangesAsync();
            return combustivel;
        }

        public async Task<TipoCombustivelModel> UpdateCombustivel(TipoCombustivelModel combustivel, int id)
        {
            TipoCombustivelModel combustiveis = await GetById(id);
            if (combustiveis == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                combustiveis.Combustivel = combustivel.Combustivel;

                _dbContext.TipoCombustivel.Update(combustiveis);
                await _dbContext.SaveChangesAsync();
            }
            return combustiveis;

        }

        public async Task<bool> DeleteCombustivel(int id)
        {
            TipoCombustivelModel combustiveis = await GetById(id);
            if (combustiveis == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.TipoCombustivel.Remove(combustiveis);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
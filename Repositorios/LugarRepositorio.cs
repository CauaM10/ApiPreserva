using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class LugarRepositorio : ILugarRepositorio
    {
        private readonly Contexto _dbContext;

        public LugarRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<LugarModel>> GetAll()
        {
            return await _dbContext.Lugar.ToListAsync();
        }

        public async Task<LugarModel> GetById(int id)
        {
            return await _dbContext.Lugar.FirstOrDefaultAsync(x => x.LugarId == id);
        }

        public async Task<LugarModel> InsertLugar(LugarModel lugar)
        {
            await _dbContext.Lugar.AddAsync(lugar);
            await _dbContext.SaveChangesAsync();
            return lugar;
        }

        public async Task<LugarModel> UpdateLugar(LugarModel lugar, int id)
        {
            LugarModel lugares = await GetById(id);
            if (lugares == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                lugares.Foto = lugar.Foto;
                lugares.EndereçoLugar = lugar.EndereçoLugar;
                lugares.DetalhesLugar = lugar.DetalhesLugar;
                lugares.ObjetivoLugar = lugar.ObjetivoLugar;

                _dbContext.Lugar.Update(lugares);
                await _dbContext.SaveChangesAsync();
            }
            return lugares;

        }

        public async Task<bool> DeleteLugar(int id)
        {
            LugarModel lugares = await GetById(id);
            if (lugares == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Lugar.Remove(lugares);
            await _dbContext.SaveChangesAsync();
            return true;
        }


    }
}
using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text.RegularExpressions;

namespace Api.Repositorios
{
    public class MarcaRepositorio : IMarcaRepositorio
    {
        private readonly Contexto _dbContext;

        public MarcaRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<MarcaModel>> GetAll()
        {
            return await _dbContext.Marca.ToListAsync();
        }

        public async Task<MarcaModel> GetById(int id)
        {
            return await _dbContext.Marca.FirstOrDefaultAsync(x => x.MarcaId == id);
        }

        public async Task<MarcaModel> InsertMarca(MarcaModel marca)
        {
            await _dbContext.Marca.AddAsync(marca);
            await _dbContext.SaveChangesAsync();
            return marca;
        }

        public async Task<MarcaModel> UpdateMarca(MarcaModel marca, int id)
        {
            MarcaModel marcas = await GetById(id);
            if (marcas == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                marcas.MarcaVeiculo = marca.MarcaVeiculo;

                _dbContext.Marca.Update(marcas);
                await _dbContext.SaveChangesAsync();
            }
            return marcas;

        }

        public async Task<bool> DeleteMarca(int id)
        {
            MarcaModel marcas = await GetById(id);
            if (marcas == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Marca.Remove(marcas);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
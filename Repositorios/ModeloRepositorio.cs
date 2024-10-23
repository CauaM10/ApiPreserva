using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class ModeloRepositorio : IModeloRepositorio
    {
        private readonly Contexto _dbContext;

        public ModeloRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ModeloModel>> GetAll()
        {
            return await _dbContext.Modelo.ToListAsync();
        }

        public async Task<ModeloModel> GetById(int id)
        {
            return await _dbContext.Modelo.FirstOrDefaultAsync(x => x.ModeloId == id);
        }

        public async Task<ModeloModel> InsertModelo(ModeloModel modelo)
        {
            await _dbContext.Modelo.AddAsync(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }

        public async Task<ModeloModel> UpdateModelo(ModeloModel modelo, int id)
        {
            ModeloModel modelos = await GetById(id);
            if (modelos == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                modelos.ModeloVeiculo = modelo.ModeloVeiculo;
                modelos.Foto = modelo.Foto;
                modelos.MarcaId = modelo.MarcaId;


                _dbContext.Modelo.Update(modelos);
                await _dbContext.SaveChangesAsync();
            }
            return modelos;

        }

        public async Task<bool> DeleteModelo(int id)
        {
            ModeloModel modelos = await GetById(id);
            if (modelos == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Modelo.Remove(modelos);
            await _dbContext.SaveChangesAsync();
            return true;
        }


    }
}
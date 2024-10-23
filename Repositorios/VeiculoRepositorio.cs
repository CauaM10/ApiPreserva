using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class VeiculoRepositorio : IVeiculoRepositorio
    {
        private readonly Contexto _dbContext;

        public VeiculoRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<VeiculoModel>> GetAll()
        {
            return await _dbContext.Veiculo.Include(x => x.Motorista)
                                           .Include(x=> x.TipoCombustivel)
                                           .Include(x=> x.Modelo).ToListAsync();
        }

        public async Task<VeiculoModel> GetById(int id)
        {
            return await _dbContext.Veiculo.Include(x => x.Motorista)
                                            .Include(x => x.TipoCombustivel)
                                           .Include(x => x.Modelo)
                                           .FirstOrDefaultAsync(x => x.VeiculoId == id);
        }

        public async Task<VeiculoModel> InsertVeiculo(VeiculoModel veiculo)
        {
            await _dbContext.Veiculo.AddAsync(veiculo);
            await _dbContext.SaveChangesAsync();
            return veiculo;
        }

        public async Task<VeiculoModel> UpdateVeiculo(VeiculoModel veiculo, int id)
        {
            VeiculoModel veiculos = await GetById(id);
            if (veiculos == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                veiculos.ModeloId = veiculo.ModeloId; 
                veiculos.HodometroVeiculo = veiculo.HodometroVeiculo;
                veiculos.TipoCombustivelId = veiculo.TipoCombustivelId;
                veiculos.Consumo = veiculo.Consumo;
                veiculos.MotoristaId = veiculo.MotoristaId;

                _dbContext.Veiculo.Update(veiculos);
                await _dbContext.SaveChangesAsync();
            }
            return veiculos;

        }

        public async Task<bool> DeleteVeiculo(int id)
        {
            VeiculoModel veiculos = await GetById(id);
            if (veiculos == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Veiculo.Remove(veiculos);
            await _dbContext.SaveChangesAsync();
            return true;
        }


    }
}
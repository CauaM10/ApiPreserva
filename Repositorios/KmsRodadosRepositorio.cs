using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class KmsRodadosRepositorio : IKmsRodadosRepositorio
    {
        private readonly Contexto _dbContext;

        public KmsRodadosRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<KmsRodadosModel>> GetAll()
        {
            return await _dbContext.KmsRodados.Include(x => x.Veiculo).ToListAsync();
        }

        public async Task<KmsRodadosModel> GetById(int id)
        {
            return await _dbContext.KmsRodados.Include(x => x.Veiculo).FirstOrDefaultAsync(x => x.KmsRodadosId == id);
        }

        public async Task<KmsRodadosModel> InsertKmsRodados(KmsRodadosModel kmsRodados)
        {
            await _dbContext.KmsRodados.AddAsync(kmsRodados);
            await _dbContext.SaveChangesAsync();
            return kmsRodados;
        }

        public async Task<KmsRodadosModel> UpdateKmsRodados(KmsRodadosModel kmsRodados, int id)
        {
            KmsRodadosModel kmsRodadoss = await GetById(id);
            if (kmsRodadoss == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                kmsRodadoss.VeiculoId = kmsRodados.VeiculoId;
                kmsRodadoss.KmsRodados = kmsRodados.KmsRodados;
                kmsRodadoss.KmsData = kmsRodados.KmsData;
            

                _dbContext.KmsRodados.Update(kmsRodadoss);
                await _dbContext.SaveChangesAsync();
            }
            return kmsRodadoss;

        }

        public async Task<bool> DeleteKmsRodados(int id)
        {
            KmsRodadosModel kmsRodadoss = await GetById(id);
            if (kmsRodadoss == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.KmsRodados.Remove(kmsRodadoss);
            await _dbContext.SaveChangesAsync();
            return true;
        }


    }
}
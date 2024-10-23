using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class SobreNosRepositorio : ISobreNosRepositorio
    {
        private readonly Contexto _dbContext;

        public SobreNosRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SobreNosModel>> GetAll()
        {
            return await _dbContext.SobreNos.ToListAsync();
        }

        public async Task<SobreNosModel> GetById(int id)
        {
            return await _dbContext.SobreNos.FirstOrDefaultAsync(x => x.SobreNosId == id);
        }

        public async Task<SobreNosModel> InsertSobreNos(SobreNosModel sobreNos)
        {
            await _dbContext.SobreNos.AddAsync(sobreNos);
            await _dbContext.SaveChangesAsync();
            return sobreNos;
        }

        public async Task<SobreNosModel> UpdateSobreNos(SobreNosModel sobreNos, int id)
        {
            SobreNosModel sobreNoss = await GetById(id);
            if (sobreNoss == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                sobreNoss.SobreEmpresa = sobreNos.SobreEmpresa;
                sobreNoss.ServicoEmpresa = sobreNos.ServicoEmpresa;
                sobreNoss.ObjetivoEmpresa = sobreNos.ObjetivoEmpresa;

                _dbContext.SobreNos.Update(sobreNoss);
                await _dbContext.SaveChangesAsync();
            }
            return sobreNoss;

        }

        public async Task<bool> DeleteSobreNos(int id)
        {
            SobreNosModel sobreNoss = await GetById(id);
            if (sobreNoss == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.SobreNos.Remove(sobreNoss);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
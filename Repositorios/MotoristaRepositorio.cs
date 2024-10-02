using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class MotoristaRepositorio : IMotoristaRepositorio
    {
        private readonly Contexto _dbContext;

        public MotoristaRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<MotoristaModel>> GetAll()
        {
            return await _dbContext.Motorista.ToListAsync();
        }

        public async Task<MotoristaModel> GetById(int id)
        {
            return await _dbContext.Motorista.FirstOrDefaultAsync(x => x.MotoristaId == id);
        }

        public async Task<MotoristaModel> InsertMotorista(MotoristaModel motorista)
        {
            await _dbContext.Motorista.AddAsync(motorista);
            await _dbContext.SaveChangesAsync();
            return motorista;
        }

        public async Task<MotoristaModel> UpdateMotorista(MotoristaModel motorista, int id)
        {
            MotoristaModel motoristas = await GetById(id);
            if (motoristas == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                motoristas.NomeMotorista = motorista.NomeMotorista;
                motoristas.TelefoneMotorista = motorista.TelefoneMotorista;
                motoristas.EmailMotorista = motorista.EmailMotorista;
                motoristas.CpfMotorista = motorista.CpfMotorista;
                motoristas.IdadeMotorista = motorista.IdadeMotorista;

                _dbContext.Motorista.Update(motoristas);
                await _dbContext.SaveChangesAsync();
            }
            return motoristas;

        }

        public async Task<bool> DeleteMotorista(int id)
        {
            MotoristaModel motoristas = await GetById(id);
            if (motoristas == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Motorista.Remove(motoristas);
            await _dbContext.SaveChangesAsync();
            return true;
        }


    }
}
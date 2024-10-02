using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class CadastroEmpresaRepositorio : ICadastroEmpresaRepositorio
    {
        private readonly Contexto _dbContext;

        public CadastroEmpresaRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CadastroEmpresaModel>> GetAll()
        {
            return await _dbContext.Cadastro.ToListAsync();
        }

        public async Task<CadastroEmpresaModel> GetById(int id)
        {
            return await _dbContext.Cadastro.FirstOrDefaultAsync(x => x.CadastroEmpresaId == id);
        }

        public async Task<CadastroEmpresaModel> InsertEmpresa(CadastroEmpresaModel empresa)
        {
            await _dbContext.Cadastro.AddAsync(empresa);
            await _dbContext.SaveChangesAsync();
            return empresa;
        }

        public async Task<CadastroEmpresaModel> UpdateEmpresa(CadastroEmpresaModel empresa, int id)
        {
            CadastroEmpresaModel empresas = await GetById(id);
            if(empresas == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                empresas.NomeEmpresa = empresa.NomeEmpresa;
                empresas.CnpjEmpresa = empresa.CnpjEmpresa;
                empresas.TelefoneEmpresa = empresa.TelefoneEmpresa;
                empresas.EmailEmpresa = empresa.EmailEmpresa;
                empresas.SenhaEmpresa = empresa.SenhaEmpresa;
                _dbContext.Cadastro.Update(empresas);
                await _dbContext.SaveChangesAsync();
            }
            return empresas;
           
        }

        public async Task<CadastroEmpresaModel> Login(string senha, string email)
        {
            return await _dbContext.Cadastro.FirstOrDefaultAsync(x => x.EmailEmpresa == email && x.SenhaEmpresa == senha);
        }

        public async Task<bool> DeleteEmpresa(int id)
        {
            CadastroEmpresaModel empresas = await GetById(id);
            if (empresas == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Cadastro.Remove(empresas);
            await _dbContext.SaveChangesAsync();
            return true;
        }    
       
    }
}

using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface ICadastroEmpresaRepositorio
    {
        Task<List<CadastroEmpresaModel>> GetAll();

        Task<CadastroEmpresaModel> GetById(int id);

        Task<CadastroEmpresaModel> InsertEmpresa(CadastroEmpresaModel empresa);

        Task<CadastroEmpresaModel> UpdateEmpresa(CadastroEmpresaModel empresa, int id);

        Task<CadastroEmpresaModel> Login(string senha, string email);


        Task<bool> DeleteEmpresa(int id);
    }
}

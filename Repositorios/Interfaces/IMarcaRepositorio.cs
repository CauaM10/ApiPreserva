using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IMarcaRepositorio
    {
        Task<List<MarcaModel>> GetAll();

        Task<MarcaModel> GetById(int id);

        Task<MarcaModel> InsertMarca(MarcaModel marca);

        Task<MarcaModel> UpdateMarca(MarcaModel marca, int id);

        Task<bool> DeleteMarca(int id);
    }
}
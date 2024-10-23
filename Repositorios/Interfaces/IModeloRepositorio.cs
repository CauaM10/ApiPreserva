using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IModeloRepositorio
    {
        Task<List<ModeloModel>> GetAll();

        Task<ModeloModel> GetById(int id);

        Task<ModeloModel> InsertModelo(ModeloModel modelo);

        Task<ModeloModel> UpdateModelo(ModeloModel modelo, int id);

        Task<bool> DeleteModelo(int id);
    }
}
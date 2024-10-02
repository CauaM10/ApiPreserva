using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IVeiculoRepositorio
    {
        Task<List<VeiculoModel>> GetAll();

        Task<VeiculoModel> GetById(int id);

        Task<VeiculoModel> InsertVeiculo(VeiculoModel veiculo);

        Task<VeiculoModel> UpdateVeiculo(VeiculoModel veiculo, int id);

        Task<bool> DeleteVeiculo(int id);
    }
}

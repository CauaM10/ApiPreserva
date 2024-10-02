using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IConsumoRepositorio
    {
        Task<List<ConsumoModel>> GetAll();

        Task<ConsumoModel> GetById(int id);

        Task<ConsumoModel> InsertConsumo(ConsumoModel consumo);

        Task<ConsumoModel> UpdateConsumo(ConsumoModel consumo, int id);

        Task<bool> DeleteConsumo(int id);
    }
}

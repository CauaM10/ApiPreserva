using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface ITipoCombustivelRepositorio
    {
        Task<List<TipoCombustivelModel>> GetAll();

        Task<TipoCombustivelModel> GetById(int id);

        Task<TipoCombustivelModel> InsertCombustivel(TipoCombustivelModel combustivel);

        Task<TipoCombustivelModel> UpdateCombustivel(TipoCombustivelModel combustivel, int id);

        Task<bool> DeleteCombustivel(int id);
    }
}

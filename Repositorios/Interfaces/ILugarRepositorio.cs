using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface ILugarRepositorio
    {
        Task<List<LugarModel>> GetAll();

        Task<LugarModel> GetById(int id);

        Task<LugarModel> InsertLugar(LugarModel lugar);

        Task<LugarModel> UpdateLugar(LugarModel lugar, int id);

        Task<bool> DeleteLugar(int id);
    }
}
using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface ISobreNosRepositorio
    {
        Task<List<SobreNosModel>> GetAll();

        Task<SobreNosModel> GetById(int id);

        Task<SobreNosModel> InsertSobreNos(SobreNosModel sobreNos);

        Task<SobreNosModel> UpdateSobreNos(SobreNosModel sobreNos, int id);

        Task<bool> DeleteSobreNos(int id);
    }
}

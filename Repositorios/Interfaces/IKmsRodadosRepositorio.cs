using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IKmsRodadosRepositorio
    {
        Task<List<KmsRodadosModel>> GetAll();

        Task<KmsRodadosModel> GetKmVeiculoDia(int id, string date );

        Task<int> GetKmVeiculoMes(int id, int mes);

        Task<KmsRodadosModel> GetById(int id);

        Task<KmsRodadosModel> InsertKmsRodados(KmsRodadosModel kmsRodados);

        Task<KmsRodadosModel> UpdateKmsRodados(KmsRodadosModel kmsRodados, int id);

        Task<bool> DeleteKmsRodados(int id);
    }
}
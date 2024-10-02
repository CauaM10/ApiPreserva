using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IMotoristaRepositorio
    {
        Task<List<MotoristaModel>>GetAll();

        Task<MotoristaModel>GetById(int id);

        Task<MotoristaModel>InsertMotorista(MotoristaModel motorista);

        Task<MotoristaModel>UpdateMotorista(MotoristaModel motorista, int id);

        Task<bool>DeleteMotorista(int id); 
    }
}

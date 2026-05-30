using Calculadora.Aplication.DTO;
using Calculadora.Domain.Entities;

namespace Calculadora.Domain.Repositories
{
    public interface IOperacionRepository
    {
        Task<bool> Insertar(Operacion oOp);
        Task<bool> InsertarOperacionCorrecta(Operacion oOp);
        Task<List<OperacionListarResponse>> Listar();
    }
}

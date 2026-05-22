using Calculadora.DTO;
using Calculadora.Models;
using Calculadora.Service;

namespace Calculadora.Repository
{
    public interface IOperacionRepository
    {
        Task<bool> Insertar(Operacion oOp);
        Task<bool> InsertarOperacionCorrecta(Operacion oOp);
        Task<List<OperacionListarResponse>> Listar();
        
    }
}

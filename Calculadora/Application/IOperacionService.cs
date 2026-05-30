using Calculadora.Aplication.DTO;

namespace Calculadora.Application
{
    public interface IOperacionService
    {
        Task<bool> Insertar(OperacionInsertarRequest oOp);
        Task<bool> InsertarOperacionCorrecta(OperacionInsertarRequest oOp);

        Task<List<OperacionListarResponse>> Listar();
    }
}

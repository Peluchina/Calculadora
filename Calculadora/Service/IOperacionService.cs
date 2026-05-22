using Calculadora.DTO;

namespace Calculadora.Service
{
    public interface IOperacionService
    {
        public Task<bool> Insertar(OperacionInsertarRequest oOp);
        public Task<bool> InsertarOperacionCorrecta(OperacionInsertarRequest oOp);

        Task<List<OperacionListarResponse>> Listar();

    }
}

using Calculadora.Aplication.DTO;
using Calculadora.Domain.Entities;
using Calculadora.Domain.Repositories;
using Calculadora.Application;

namespace Calculadora.Application
{
    public abstract class OperacionBaseService : IOperacionService
    {
        private readonly IOperacionRepository _operacionRepository;

        public OperacionBaseService(IOperacionRepository operacionRepository)
        {
            _operacionRepository = operacionRepository;
        }

        public abstract string GetMensajeNotify();

        public abstract void Calcular(OperacionInsertarRequest oOp);

        public async Task<bool> Insertar(OperacionInsertarRequest oOp)
        {
            Calcular(oOp);
            var entidad = new Operacion(oOp, GetMensajeNotify());
            return await _operacionRepository.Insertar(entidad);
        }

        public async Task<bool> InsertarOperacionCorrecta(OperacionInsertarRequest oOp)
        {
            var entidad = new Operacion(oOp, GetMensajeNotify());
            return await _operacionRepository.InsertarOperacionCorrecta(entidad);
        }

        public async Task<List<OperacionListarResponse>> Listar()
        {
            return await _operacionRepository.Listar();
        }
    }
}

using Calculadora.DTO;
using Calculadora.Models;
using Calculadora.Repository;

namespace Calculadora.Service
{
    public abstract class OperacionBaseService : IOperacionService
    {
        private readonly IOperacionRepository _operacionRepository;

        protected OperacionBaseService(IOperacionRepository operacionRepository)
        {
            this._operacionRepository = operacionRepository;
        }

        public async Task<bool> Insertar(OperacionInsertarRequest oOp)
        {

            var entidad = new Operacion(oOp, GetMensajeNotify());
            return await _operacionRepository.Insertar(entidad);
        }

        public async Task<List<OperacionListarResponse>> Listar()
        {
            return await _operacionRepository.Listar();
        }

        public abstract string GetMensajeNotify();

        public async Task<bool> InsertarOperacionCorrecta(OperacionInsertarRequest oOp)
        {
            var entidad = new Operacion(oOp, GetMensajeNotify());
            return await _operacionRepository.InsertarOperacionCorrecta(entidad);
        }
    }
}

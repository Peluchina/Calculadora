using Calculadora.DTO;
using Calculadora.Models;
using Calculadora.Repository;

namespace Calculadora.Service
{
    public class OperacionService : OperacionBaseService, IOperacionService
    {
        private readonly string _mensajePersonalizado;
        public OperacionService(IOperacionRepository operacionRepository, string mensaje) : base(operacionRepository)
        {
            _mensajePersonalizado = mensaje;
        }

        public override string GetMensajeNotify()
        {
            return _mensajePersonalizado;
        }
    }
}

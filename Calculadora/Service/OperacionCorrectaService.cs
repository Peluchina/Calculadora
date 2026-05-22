using Calculadora.Repository;

namespace Calculadora.Service
{
    public class OperacionCorrectaService:OperacionBaseService, IOperacionService
    {
        private readonly string _mensajePersonalizado;

        public OperacionCorrectaService(IOperacionRepository operacionRepository, string mensaje) : base(operacionRepository)
        {
            _mensajePersonalizado = mensaje;
        }

        public override string GetMensajeNotify()
        {
            return _mensajePersonalizado;
        }
    }
}

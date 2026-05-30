using Calculadora.Aplication.DTO;
using Calculadora.Domain.Repositories;
using Calculadora.Application;

namespace Calculadora.Domain.Service
{
    public class OperacionInversaService : OperacionBaseService, IOperacionService
    {
        private string _mensajePersonalizado;

        public OperacionInversaService(IOperacionRepository operacionRepository) : base(operacionRepository)
        {
            _mensajePersonalizado = "";
        }

        public override string GetMensajeNotify()
        {
            return _mensajePersonalizado;
        }

        public override void Calcular(OperacionInsertarRequest oOp)
        {
            if (oOp.IdOperador == 0)
            {
                throw new ArgumentException("Por favor, seleccione un tipo de operación válido.");
            }

            if (oOp.IdOperador == 1)
            {
                oOp.Resultado = (decimal)(oOp.NumeroUno - oOp.NumeroDos);
                _mensajePersonalizado = "Esta operación es inversa, se esta restando";
            }
            else if (oOp.IdOperador == 2)
            {
                oOp.Resultado = (decimal)(oOp.NumeroUno + oOp.NumeroDos);
                _mensajePersonalizado = "Esta operación es inversa, se esta sumando";
            }
            else if (oOp.IdOperador == 3)
            {
                if (oOp.NumeroDos == 0)
                {
                    throw new ArgumentException("Error: No se puede dividir entre cero.");
                }

                oOp.Resultado = (decimal)(oOp.NumeroUno / oOp.NumeroDos);
                _mensajePersonalizado = "Esta operación es inversa, se esta dividiendo";
            }
            else if (oOp.IdOperador == 4)
            {
                oOp.Resultado = oOp.NumeroUno * oOp.NumeroDos;
                _mensajePersonalizado = "Esta operación es inversa, se esta multiplicando";
            }
        }
    }

     
}

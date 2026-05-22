using Calculadora.DTO;
using Calculadora.Repository;

namespace Calculadora.Service
{
    public class OperacionCorrectaService:OperacionBaseService, IOperacionService
    {
        private string _mensajePersonalizado;

        public OperacionCorrectaService(IOperacionRepository operacionRepository) : base(operacionRepository)
        {
            _mensajePersonalizado = "";
        }

        public override void Calcular(OperacionInsertarRequest oOp)
        {
            if (oOp.IdOperador == 0)
            {
                throw new ArgumentException("Por favor, seleccione un tipo de operación válido.");
            }

            if (oOp.IdOperador == 1)
            {
                oOp.Resultado = (decimal)(oOp.NumeroUno + oOp.NumeroDos);
                _mensajePersonalizado = "Se esta sumando";
            }
            else if (oOp.IdOperador == 2)
            {
                oOp.Resultado = (decimal)(oOp.NumeroUno - oOp.NumeroDos);
                _mensajePersonalizado = "Se esta restando";
            }
            else if (oOp.IdOperador == 3)
            {
                if (oOp.NumeroDos == 0)
                {
                    throw new ArgumentException("Error: No se puede dividir entre cero.");
                }

                oOp.Resultado = (decimal)(oOp.NumeroUno * oOp.NumeroDos);
                _mensajePersonalizado = "Se esta multiplicando";
            }
            else if (oOp.IdOperador == 4)
            {
                oOp.Resultado = oOp.NumeroDos != 0 ? (decimal)oOp.NumeroUno / oOp.NumeroDos : 0;
                _mensajePersonalizado = "Se esta dividiendo";
            }
        }

        public override string GetMensajeNotify()
        {
            return _mensajePersonalizado;
        }
    }
}

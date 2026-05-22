using Calculadora.DTO;
using Calculadora.Repository;

namespace Calculadora.Service
{
    public class OperacionServiceFactory
    {
        private readonly IOperacionRepository _repository;

        public OperacionServiceFactory(IOperacionRepository _repository)
        {
            this._repository = _repository;
        }

        public IOperacionService CreateService(OperacionInsertarRequest oOp)
        {
            string mensajeNotificacion = "";

            if (oOp.IdOperador == 0)
            {
                throw new ArgumentException("Por favor, seleccione un tipo de operación válido.");
            }

            if (oOp.IdOperador == 1)
            {
                oOp.Resultado = (decimal)(oOp.NumeroUno - oOp.NumeroDos);
                mensajeNotificacion = "Esta operación es inversa, se esta restando";
            }
            else if (oOp.IdOperador == 2) 
            { 
                oOp.Resultado = (decimal)(oOp.NumeroUno + oOp.NumeroDos);
                mensajeNotificacion = "Esta operación es inversa, se esta sumando";
            }
            else if (oOp.IdOperador == 3)
            {
                if (oOp.NumeroDos == 0)
                {
                    throw new ArgumentException("Error: No se puede dividir entre cero.");
                } 

                oOp.Resultado = (decimal)(oOp.NumeroUno / oOp.NumeroDos);
                mensajeNotificacion = "Esta operación es inversa, se esta dividiendo";
            }
            else if (oOp.IdOperador == 4)
            {
                oOp.Resultado = oOp.NumeroDos != 0 ? (decimal)oOp.NumeroUno * oOp.NumeroDos : 0;
                mensajeNotificacion = "Esta operación es inversa, se esta multiplicando";
            }

            return new OperacionService(_repository,mensajeNotificacion);
        }

        public IOperacionService CreateOperacionCorrectaService(OperacionInsertarRequest oOp)
        {
            string mensajeNotificacion = "";

            if (oOp.IdOperador == 0)
            {
                throw new ArgumentException("Por favor, seleccione un tipo de operación válido.");
            }

            if (oOp.IdOperador == 1)
            {
                oOp.Resultado = (decimal)(oOp.NumeroUno + oOp.NumeroDos);
                mensajeNotificacion = "Se esta sumando";
            }
            else if (oOp.IdOperador == 2)
            {
                oOp.Resultado = (decimal)(oOp.NumeroUno - oOp.NumeroDos);
                mensajeNotificacion = "Se esta restando";
            }
            else if (oOp.IdOperador == 3)
            {
                if (oOp.NumeroDos == 0)
                {
                    throw new ArgumentException("Error: No se puede dividir entre cero.");
                }

                oOp.Resultado = (decimal)(oOp.NumeroUno * oOp.NumeroDos);
                mensajeNotificacion = "Se esta multiplicando";
            }
            else if (oOp.IdOperador == 4)
            {
                oOp.Resultado = oOp.NumeroDos != 0 ? (decimal)oOp.NumeroUno / oOp.NumeroDos : 0;
                mensajeNotificacion = "Se esta dividiendo";
            }

            return new OperacionService(_repository, mensajeNotificacion);
        }


        public IOperacionService ListarServicio()
        {
            return new OperacionService(_repository,"");
        }


    }
}

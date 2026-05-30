using Calculadora.Aplication.DTO;

namespace Calculadora.Domain.Entities
{
    public class Operacion
    {
        public int IdOperacion { get; set; }
        public int? NumeroUno { get; set; }
        public int? NumeroDos { get; set; }
        public decimal? Resultado { get; set; }
        public int? IdOperador { get; set; }
        public string? Mensaje { get; set; }

        public Operacion(OperacionInsertarRequest oRequest, string mensaje)
        {
            this.NumeroUno = oRequest.NumeroUno;
            this.NumeroDos = oRequest.NumeroDos;
            this.IdOperador = oRequest.IdOperador;
            this.Resultado = oRequest.Resultado;
            this.Mensaje = mensaje;
        }
    }
}

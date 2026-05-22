namespace Calculadora.DTO
{
    public class OperacionListarResponse
    {
        public int IdOperacion { get; set; }
        public int? NumeroUno { get; set; }
        public int? NumeroDos { get; set; }
        public decimal? Resultado { get; set; }
        public string? NomOperador { get; set; }
        public string? Mensaje { get; set; }
    }
}

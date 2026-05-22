using Calculadora.Repository;
using Microsoft.Data.SqlClient;
using System.Data;


namespace Calculadora.Data
{
    public class ConexionBD
    {
        protected readonly string _conexion;
        protected readonly ILogger<OperacionRepository> _logger;

        public ConexionBD(string conexion, ILogger<OperacionRepository> logger)
        {
            _conexion = conexion;
            _logger = logger;
        }

        protected IDbConnection CrearConexion() => new SqlConnection(_conexion);


    }
}

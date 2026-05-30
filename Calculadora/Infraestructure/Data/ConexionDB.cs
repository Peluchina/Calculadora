using System.Data;
//using System.Data.SqlClient;
using Calculadora.Infraestructure.Repository;
using Microsoft.Data.SqlClient;

namespace Calculadora.Infraestructure.Data
{
    public class ConexionDB
    {
        protected readonly string _conexion;
        protected readonly ILogger<OperacionRepository> _logger;

        public ConexionDB(string conexion, ILogger<OperacionRepository> logger)
        {
            _conexion = conexion;
            _logger = logger;
        }

        protected IDbConnection CrearConexion() => new SqlConnection(_conexion);

    }
}

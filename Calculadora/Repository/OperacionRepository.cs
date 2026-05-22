using Calculadora.Data;
using Calculadora.DTO;
using Calculadora.Models;
using System.Data;
using Dapper;

namespace Calculadora.Repository
{
    public class OperacionRepository : ConexionBD,IOperacionRepository
    {
        public OperacionRepository(string conexion, ILogger<OperacionRepository> logger) : base(conexion, logger){}
        public async Task<bool> Insertar(Operacion oOp)
        {
            try
            {
                using var con = CrearConexion();
                var parametros = new
                {
                    //oOp.IdOperacion,
                    oOp.NumeroUno,
                    oOp.NumeroDos,
                    oOp.Resultado,
                    oOp.IdOperador,
                    oOp.Mensaje
                };

                int filasAfectadas = await con.ExecuteAsync(
                    "SP_InsertarOperacion",
                    parametros,
                    commandType: CommandType.StoredProcedure);

                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear contenido");
                throw;
            }
        }

        public async Task<bool> InsertarOperacionCorrecta(Operacion oOp)
        {
            try
            {
                using var con = CrearConexion();

                var parametros = new
                {
                    //oOp.IdOperacion,
                    oOp.NumeroUno,
                    oOp.NumeroDos,
                    oOp.Resultado,
                    oOp.IdOperador,
                    oOp.Mensaje
                };

                int filasAfectadas = await con.ExecuteAsync(
                    "SP_InsertarOperacion",
                    parametros,
                    commandType: CommandType.StoredProcedure);

                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear contenido");
                throw;
            }
        }

        public async Task<List<OperacionListarResponse>> Listar()
        {
            try
            {
                using var con = CrearConexion();

                var resultado = await con.QueryAsync<OperacionListarResponse>(
                    "SP_Listar",
                    commandType: CommandType.StoredProcedure);

                return resultado.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al listar datos");
                throw;
            }
        }

        
    }
}

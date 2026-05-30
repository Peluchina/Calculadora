
using Calculadora.Domain.Entities;
using Calculadora.Aplication.DTO;
using Calculadora.Infraestructure.Data;
using Calculadora.Domain.Repositories;
using Dapper;
using System.Data;


namespace Calculadora.Infraestructure.Repository
{
    public class OperacionRepository : ConexionDB, IOperacionRepository
    {
        public OperacionRepository(string conexion, ILogger<OperacionRepository> logger) : base(conexion, logger) { }

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

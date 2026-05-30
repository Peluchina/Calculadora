
using Calculadora.Domain.Factories;
using Microsoft.AspNetCore.Mvc;
using Calculadora.Application;
using Calculadora.Aplication.DTO;



namespace Calculadora.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacionController : ControllerBase
    {
        private readonly OperacionFactory serviceFactory;

        public OperacionController(OperacionFactory serviceFactory)
        {
            this.serviceFactory = serviceFactory;
        }

        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] OperacionInsertarRequest oOp)
        {
            IOperacionService _operacionService = serviceFactory.CreateService();
            bool respuesta = await _operacionService.Insertar(oOp);

            return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta, resultadoCalculado = oOp.Resultado });
        }


        [HttpPost("InsertarOpC")]
        public async Task<IActionResult> InsertarOpC([FromBody] OperacionInsertarRequest oOp)
        {
            IOperacionService _operacionService = serviceFactory.CreateOperacionCorrectaService();
            bool respuesta = await _operacionService.Insertar(oOp);

            return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta, resultadoCalculado = oOp.Resultado });
        }


        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            var service = serviceFactory.ListarServicio();
            var lista = await service.Listar();
            return Ok(new { data = lista });
        }
    }
}

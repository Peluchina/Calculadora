using Calculadora.DTO;
using Calculadora.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Calculadora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacionController : ControllerBase
    {
        private readonly OperacionServiceFactory serviceFactory;

        public OperacionController(OperacionServiceFactory serviceFactory)
        {
            this.serviceFactory = serviceFactory;
        }

        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] OperacionInsertarRequest oOp)
        {
            IOperacionService _operacionService = serviceFactory.CreateService(oOp);
            bool respuesta = await _operacionService.Insertar(oOp);

            return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta, resultadoCalculado = oOp.Resultado });
        }


        [HttpPost("InsertarOpC")]
        public async Task<IActionResult> InsertarOpC([FromBody] OperacionInsertarRequest oOp)
        {
            IOperacionService _operacionService = serviceFactory.CreateOperacionCorrectaService(oOp);
            bool respuesta = await _operacionService.Insertar(oOp);

            return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta, resultadoCalculado = oOp.Resultado });
        }


        [HttpGet]
        public async Task<IActionResult>Lista()
        {
            var service= serviceFactory.ListarServicio();
            var lista = await service.Listar();
            return Ok(new {data=lista});
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/factura")]
    [ApiController]
    public class FacturaController : Controller
    {
        private readonly IFacturaRestService _facturaService;

        public FacturaController(IFacturaRestService facturaService)
        {
            _facturaService = facturaService;
        }

        [HttpGet]
        [Route("findFacturasByPersona/{identificacion}")]
        public async Task<IActionResult> findFacturasByPersona(string identificacion)
        {
            try
            {
                var rsp = await _facturaService.findFacturaByPersona(identificacion);
                return Ok(rsp);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al encontrar las facturas");
                Console.WriteLine(ex.ToString());
            }

            return Ok();
        }
        [HttpPost]
        [Route("storeFactura")]
        public async Task<IActionResult> storeFactura([FromBody] Factura request)
        {
            try
            {
                var rsp = await _facturaService.storeFactura(request);
                return Ok(request);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al insertar la factura");
                Console.Write(e.ToString());
            }
            return Ok();
        }

    }
}

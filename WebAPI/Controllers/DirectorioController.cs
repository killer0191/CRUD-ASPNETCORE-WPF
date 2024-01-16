using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/directorio")]
    [ApiController]
    public class DirectorioController : Controller
    {
        private readonly IDirectorioRestService _directorioService;

        public DirectorioController(IDirectorioRestService directorioService)
        {
            _directorioService = directorioService;
        }

        [HttpGet]
        [Route("findPersonaByIdentificacion/{identificacion}")]
        public async Task<IActionResult> findPersonaByIdentificacion(string identificacion)
        {
            try
            {
                var rsp = await _directorioService.findPersonaByIdentificacion(identificacion);
                return Ok(rsp);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al encontrar la persona");
                Console.WriteLine(ex.ToString());
            }

            return Ok();
        }
        [HttpGet]
        [Route("findPersonas")]
        public async Task<IActionResult> findPersonas()
        {
            try
            {
                var rsp = await _directorioService.findPersonas();
                return Ok(rsp);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al encontrar las personas");
                Console.WriteLine(ex.ToString());
            }

            return Ok();
        }
        [HttpDelete]
        [Route("deletePersonaByIdentificacion/{identificacion}")]
        public async Task<IActionResult> deletePersonaByIdentificacion(string identificacion)
        {
            var eliminarPersona = await _directorioService.deletePersonaByIdentificacion(identificacion);
            if (eliminarPersona == false)
            {
                
                return BadRequest("Error al eliminar la persona");
            }
            return Ok();
        }
        [HttpPost]
[Route("storePersona")]
public async Task<IActionResult> storePersona([FromBody] Persona request)
{
    try
    {
        var personaRegistrada = await _directorioService.storePersona(request);

        if (personaRegistrada)
        {
            return Ok(request);
        }
        else
        {
            return BadRequest("La persona con la misma identificación ya existe.");
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("Error al insertar la persona");
        Console.Write(e.ToString());
        return BadRequest("Error al insertar la persona.");
    }
}

    }
}

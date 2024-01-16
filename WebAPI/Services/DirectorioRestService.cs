using WebAPI.DataTransfer;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class DirectorioRestService : IDirectorioRestService
    {
        private readonly Directorio _directorio;
        private readonly ILogger<Directorio> _logger;
        public DirectorioRestService(Directorio directorio, ILogger<Directorio> logger)
        {
            _directorio = directorio;
            _logger = logger;
        }
        public async Task<bool> deletePersonaByIdentificacion(string identificacion)
        {
            _logger.LogWarning("Metodo deletePersonaByIdentificacion invocado");
            bool result = await _directorio.deletePersonaByIdentificacion(identificacion);
            _logger.LogWarning("Resultado: " + result);
            return  result;
        }

        public async Task<IQueryable<Persona>> findPersonaByIdentificacion(string identificacion)
        {
            _logger.LogWarning("Metodo findPersonaByIdentificacion invocado");
            IQueryable<Persona> personas = await _directorio.findPersonaByIdentificacion(identificacion);
            var personasList = personas.ToList();

            foreach (var persona in personasList)
            {
                _logger.LogWarning($"Resultado: IdPersona: {persona.IdPersona}, Nombre: {persona.Nombre}, ApellidoPaterno: {persona.ApellidoPaterno}, Identificacion: {persona.Identificacion}");
            }

            return personas;
        }


        public async Task<IQueryable<Persona>> findPersonas()
        {
            _logger.LogWarning("Metodo findPersonas invocado");
            IQueryable<Persona> personas = await _directorio.findPersonas();
            var personasList = personas.ToList();
            foreach (var persona in personasList)
            {
                _logger.LogWarning($"Resultado: IdPersona: {persona.IdPersona}, Nombre: {persona.Nombre}, ApellidoPaterno: {persona.ApellidoPaterno}, Identificacion: {persona.Identificacion}");
            }

            return personas;
        }


        public async Task<bool> storePersona(Persona modelo)
        {
            _logger.LogWarning("Metodo storePersona invocado");
            bool result = await _directorio.storePersona(modelo);
            _logger.LogWarning("Resultado: " + result);
            return result;
        }
    }
}

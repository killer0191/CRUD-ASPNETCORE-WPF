using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.DataTransfer
{
    public class Directorio
    {
        private readonly IPersonaRepository<Persona> _personaRepo;
        public Directorio(IPersonaRepository<Persona> personaRepo)
        {
            _personaRepo = personaRepo;
        }
        public async Task<IQueryable<Persona>> findPersonaByIdentificacion(string identificacion)
        {
            IQueryable<Persona> querySQL = await _personaRepo.ObtenerTodo();
            IQueryable<Persona> persona = querySQL.Where(c => c.Identificacion == identificacion);
            return persona;
        }
        public async Task<IQueryable<Persona>> findPersonas()
        {
            return await _personaRepo.ObtenerTodo();
        }
        public async Task<bool> deletePersonaByIdentificacion(string identificacion)
        {
            return await _personaRepo.Eliminar(identificacion);
        }
        public async Task<bool> storePersona(Persona modelo)
{
    // Obtiene la colección de personas de manera asíncrona
    IQueryable<Persona> personas = await _personaRepo.ObtenerTodo();

    // Valida si ya existe una persona con la misma identificación
    bool personaExistente = await personas.AnyAsync(p => p.Identificacion == modelo.Identificacion);

    if (personaExistente)
    {
        // Si ya existe una persona con la misma identificación, puedes manejar el error o simplemente retornar false
        return false;
    }

    // Si no existe una persona con la misma identificación, procede con el almacenamiento
    return await _personaRepo.Insertar(modelo);
}


    }
}
using WebAPI.Models;
namespace WebAPI.Services
{
    public interface IDirectorioRestService
    {
        Task<IQueryable<Persona>> findPersonaByIdentificacion(string identificacion);
        Task<IQueryable<Persona>> findPersonas();
        Task<bool> deletePersonaByIdentificacion(string identificacion);
        Task<bool> storePersona(Persona modelo);
    }
}

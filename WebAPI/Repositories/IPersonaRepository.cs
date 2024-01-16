using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface IPersonaRepository<Persona> where Persona : class
    {
        Task<bool> Insertar(Persona modelo);
        Task<bool> Actualizar(Persona modelo);
        Task<bool> Eliminar(string identificacion);
        Task<IQueryable<Persona>> ObtenerTodo();
    }
}

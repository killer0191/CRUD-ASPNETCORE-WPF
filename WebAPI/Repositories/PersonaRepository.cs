using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class PersonaRepository : IPersonaRepository<Persona>
    {
        private readonly DataContext _dbcontext;
        public PersonaRepository(DataContext context)
        {
            _dbcontext = context;
        }

        public async Task<bool> Actualizar(Persona modelo)
        {
            _dbcontext.Personas.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

      public async Task<bool> Eliminar(string identificacion)
{
    Persona modelo = await _dbcontext.Personas
        .Include(p => p.Facturas) // Incluye las facturas asociadas a la persona
        .FirstOrDefaultAsync(c => c.Identificacion == identificacion);

    if (modelo != null)
    {
        // Elimina todas las facturas asociadas a la persona
        _dbcontext.Facturas.RemoveRange(modelo.Facturas);
        
        // Elimina la persona
        _dbcontext.Personas.Remove(modelo);

        await _dbcontext.SaveChangesAsync();
        return true;
    }
    else
    {
        return false;
    }
}



        public async Task<bool> Insertar(Persona modelo)
        {
            _dbcontext.Personas.Add(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<Persona>> ObtenerTodo()
        {
            IQueryable<Persona> querySQL =  _dbcontext.Personas;
            return querySQL;
        }
    }
}
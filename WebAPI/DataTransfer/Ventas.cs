using WebAPI.Repositories;
using WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.DataTransfer
{
    public class Ventas
    {
        private readonly IFacturaRepository<Factura> _facturaRepo;
        private readonly IPersonaRepository<Persona> _personaRepo;
        public Ventas(IFacturaRepository<Factura> facturaRepo ,IPersonaRepository<Persona> personaRepo)
        {
            _facturaRepo = facturaRepo;
            _personaRepo = personaRepo;
        }
        public async Task<IQueryable<Factura>> FindFacturasByPersona(string identificacion)
        {
            // Obtener la persona por identificación
            IQueryable<Persona> queryPersonas = await _personaRepo.ObtenerTodo();
            Persona persona = await queryPersonas.FirstOrDefaultAsync(p => p.Identificacion == identificacion);

            if (persona != null)
            {
                // Guardar el Id de la persona en una variable tipo int
                int idPersona = persona.IdPersona;

                IQueryable<Factura> queryFacturas = await _facturaRepo.ObtenerTodo();

                // Filtrar las facturas por su campo IdPersona y la variable idPersona
                IQueryable<Factura> facturas = queryFacturas.Where(f => f.IdPersona == idPersona);

                return facturas;
            }

            // Si no se encuentra la persona, puedes manejarlo de la manera que prefieras, por ejemplo, retornar una lista vacía.
            return Enumerable.Empty<Factura>().AsQueryable();
        }



        public async Task<bool> storeFactura(Factura modelo)
        {
            return await _facturaRepo.Insertar(modelo);
        }
    }
}
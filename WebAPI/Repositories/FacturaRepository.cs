using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class FacturaRepository : IFacturaRepository<Factura>
    {
        private readonly DataContext _dbcontext;
        public FacturaRepository(DataContext context)
        {
            _dbcontext = context;
        }

        public async Task<bool> Actualizar(Factura modelo)
        {
            _dbcontext.Facturas.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            Factura modelo = _dbcontext.Facturas.First(c => c.IdFactura == id);
            _dbcontext.Facturas.Remove(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Factura modelo)
        {
            _dbcontext.Facturas.Add(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<Factura>> ObtenerTodo()
        {
            Console.WriteLine("Bandera 4");
            IQueryable<Factura> querySQL = _dbcontext.Facturas;
            Console.WriteLine(querySQL);
            return querySQL;
        }
    }
}
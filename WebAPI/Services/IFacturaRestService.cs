using WebAPI.Models;
namespace WebAPI.Services
{
    public interface IFacturaRestService
    {
        Task<IQueryable<Factura>> findFacturaByPersona(string identificacion);
        Task<bool> storeFactura(Factura modelo);
    }
}

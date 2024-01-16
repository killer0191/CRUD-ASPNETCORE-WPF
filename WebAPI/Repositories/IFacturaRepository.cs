namespace WebAPI.Repositories
{
    public interface IFacturaRepository<Factura> where Factura : class
    {
        Task<bool> Insertar(Factura modelo);
        Task<bool> Actualizar(Factura modelo);
        Task<bool> Eliminar(int id);
        Task<IQueryable<Factura>> ObtenerTodo();
    }
}

using WebAPI.Models;
using WebAPI.DataTransfer;
using Microsoft.Extensions.Logging;

namespace WebAPI.Services
{
    public class FacturaRestService : IFacturaRestService
    {
        private readonly Ventas _factura;
        private readonly ILogger<Ventas> _logger;
        public FacturaRestService(Ventas factura, ILogger<Ventas> logger)
        {
            _factura = factura;
            _logger = logger;   
        }
        public async Task<IQueryable<Factura>> findFacturaByPersona(string identificacion)
        {
            _logger.LogWarning("Metodo findFacturaByPersona invocado");
            IQueryable<Factura> facturas = await _factura.FindFacturasByPersona(identificacion);

            var facturasList = facturas.ToList();

            foreach (var factura in facturasList)
            {
                _logger.LogWarning($"Resultado: IdFactura: {factura.IdFactura}, Monto: {factura.Monto}, Fecha: {factura.Fecha}, IdPersona: {factura.IdPersona}");
            }
            return await _factura.FindFacturasByPersona(identificacion);
        }

        public async Task<bool> storeFactura(Factura modelo)
        {
            _logger.LogWarning("Metodo storeFactura invocado");
            bool result = await _factura.storeFactura(modelo);
            _logger.LogWarning("Resultado: " + result);
            return result;
        }
    }
}

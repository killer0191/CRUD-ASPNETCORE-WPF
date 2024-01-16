using System;
using System.ComponentModel.DataAnnotations;

namespace AppEscritorio.Models
{
    public class FacturaModel
    {
        public int IdFactura { get; set; }
        public DateTimeOffset Fecha { get; set; }
        public float Monto { get; set; }
        public int? IdPersona { get; set; }

    }
}

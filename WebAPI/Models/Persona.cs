using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public partial class Persona
    {
        [Key]
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string Identificacion { get; set; }
        //public virtual List<Factura> Facturas { get; set; }
        //public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();
        //public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
        public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    }
}

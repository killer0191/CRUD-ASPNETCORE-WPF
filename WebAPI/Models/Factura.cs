using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public partial class Factura
    {
        [Key]
        public int IdFactura { get; set; }
        public DateTimeOffset Fecha { get; set; }
        public float Monto { get; set; }
        public int? IdPersona { get; set; }
        //public virtual Persona? IdPersonaNavigation { get; set; }

    }
}

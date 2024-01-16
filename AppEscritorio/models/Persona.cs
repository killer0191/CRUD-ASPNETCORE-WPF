using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppEscritorio.Models
{
    public class PersonaModel
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string Identificacion { get; set; }
        public virtual ICollection<FacturaModel> Facturas { get; set; } = new List<FacturaModel>();

    }
}

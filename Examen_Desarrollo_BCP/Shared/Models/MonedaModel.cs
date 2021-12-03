using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Desarrollo_BCP.Shared.Models
{
    public class MonedaModel
    {
        [Required(ErrorMessage ="La moneda necesita un Codigo")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "El Codigo de la moneda debe tener 3 digitos")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "La moneda necesita un Nombre")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "El Nombre de la moneda debe tener un maximo de 50 digitos")]
        public string Nombre { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Desarrollo_BCP.Shared.Models
{
    public class CuentaModel
    {
        [Required(ErrorMessage = "El numero de cuenta es requerido")]
        [StringLength(14, MinimumLength = 13, ErrorMessage = "El numero de cuenta tiene un maximo de 13 digitos y un minimo de 14 digitos")]
        public string NRO_CUENTA { get; set; }

        [Required(ErrorMessage = "El tipo de cuenta es requerido")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "El tipo de cuenta tiene 3 digitos")]
        public string TIPO { get; set; }

        [Required(ErrorMessage = "La moneda es requerida")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "La Moneda debe tener un valor de 3 digitos")]
        public string MONEDA { get; set; }

        [Required(ErrorMessage ="El nombre es requerido")]
        [StringLength(40, ErrorMessage ="El nombre debe tener un maximo de 40 letras")]
        public string NOMBRE { get; set; }

        [Required]
        [RegularExpression(@"^\d+(\.\d{0,2})?$")]
        [Range(0, 9999999999.99)]
        public decimal SALDO { get; set; }
        
    }
}

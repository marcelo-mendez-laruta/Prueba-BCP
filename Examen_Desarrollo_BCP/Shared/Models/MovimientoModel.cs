using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Desarrollo_BCP.Shared.Models
{
    public class MovimientoModel
    {
        [Required(ErrorMessage = "El numero de cuenta es requerido")]
        [StringLength(14, MinimumLength = 13, ErrorMessage = "El numero de cuenta tiene un maximo de 13 digitos y un minimo de 14 digitos")]
        public string NRO_CUENTA { get; set; }

        [Required(ErrorMessage = "Fecha es requerida")]
        public DateTime FECHA { get; set; }

        [Required(ErrorMessage = "Tipo es requerido")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Valor D=Debito, A=Abono")]
        public string TIPO { get; set; }

        [Required]
        [RegularExpression(@"^\d+(\.\d{0,2})?$")]
        [Range(0, 9999999999.99)]
        public decimal IMPORTE { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorContactos.Shared.DTOS.MediosContactos
{
    public class MediosContactoDTO
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "El campo {0} es requerido")]
        public string TipoContacto { get; set; }

        public string Contacto { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace BlazorContactos.Shared.DTOS.Contactos
{
    public class ContactoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Nombre { get; set; }

        public string Email { get; set; }      
    }
}

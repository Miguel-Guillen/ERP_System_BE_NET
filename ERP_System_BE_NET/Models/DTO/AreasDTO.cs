using System.ComponentModel.DataAnnotations;

namespace ERP_System_BE_NET.Models.DTO
{
    public class AreasDTO
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Se requiere un nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Se requiere la descripcion")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Se requiere el jefe de area")]
        public int Jefe { get; set; }
    }
}

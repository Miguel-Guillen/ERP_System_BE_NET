using System.ComponentModel.DataAnnotations;

namespace ERP_System_BE_NET.Models
{
    public class Empleado
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Los apellidos son requeridos")]
        [StringLength(50)]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "El area es requerida")]
        [StringLength(40)]
        public string Area { get; set; }
        [Required(ErrorMessage = "El puesto es requerido")]
        [StringLength(40)]
        public string Puesto { get; set; }
        [Required(ErrorMessage = "El correo es requerido")]
        [StringLength(60)]
        public string Email { get; set; }
        [Required(ErrorMessage = "El estatus es requerido")]
        public Boolean Estado { get; set; }
        [Required(ErrorMessage = "Se requiere la fecha de ingreso")]
        [DataType(DataType.Date)]
        public DateTime Ingreso { get; set; }
    }
}

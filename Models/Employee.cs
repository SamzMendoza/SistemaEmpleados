using System.ComponentModel.DataAnnotations;

namespace SistemaEmpleados.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Nombres")]
        public string Names { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Apellidos")]
        public string Surnames { get; set; }

        [Required]
        [MaxLength(3)]
        [Display(Name = "Tipo de Documento")]
        public string DocumentType { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Documento")]
        public string Document { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Área")]
        public string Area { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Subárea")]
        public string Subarea { get; set; }
    }
}

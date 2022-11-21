using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SistemaEmpleados.Models
{
    public class Area
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Nombre de Área")]
        public string Name { get; set; }
    }
}

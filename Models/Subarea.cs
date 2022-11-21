using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SistemaEmpleados.Models
{
    public class Subarea
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Nombre de Subárea")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Área")]
        public int AreaId { get; set; }

        [ForeignKey("AreaId")]
        public Area Area { get; set; }
    }
}

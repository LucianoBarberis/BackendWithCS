using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaAPI4.Models
{
    public class Contacto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactId { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Mail { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}

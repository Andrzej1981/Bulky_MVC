using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Nazwa kategorii")]
        public string Name { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Porządek wyświetlania powinien wynosić między 1-100")]
        [DisplayName("Porządek wyświetlania")]
        public int DisplayOrder { get; set; }
    }
}

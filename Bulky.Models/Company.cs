using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ta pozycja jest wymagana")]
        [MaxLength(50, ErrorMessage = "Maksymalnie 50 znaków")]
        [Display(Name = "Nazwa firmy")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ta pozycja jest wymagana")]
        [MaxLength(50, ErrorMessage = "Maksymalnie 50 znaków")]
        [Display(Name = "Ulica")]
        public string? StreetAddress { get; set; }
        [Required(ErrorMessage = "Ta pozycja jest wymagana")]
        [MaxLength(50, ErrorMessage = "Maksymalnie 50 znaków")]
        [Display(Name = "Miasto")]
        public string? City { get; set; }
        [Required(ErrorMessage = "Ta pozycja jest wymagana")]
        [MaxLength(50, ErrorMessage = "Maksymalnie 50 znaków")]
        [Display(Name = "Województwo")]
        public string? State { get; set; }
        [Required(ErrorMessage = "Ta pozycja jest wymagana")]
        [MaxLength(10, ErrorMessage = "Maksymalnie 10 znaków")]
        [Display(Name = "Kod pocztowy")]
        public string? PostalCode { get; set; }
        [Display(Name = "Telefon")]
        public string? PhoneNumber { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Bulky.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ta pozycja jest wymagana")]
        [MaxLength(30,ErrorMessage ="Maksymalnie 30 znaków")]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Ta pozycja jest wymagana")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Ta pozycja jest wymagana")]
        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Ta pozycja jest wymagana")]
        [Display(Name = "Autor")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Ta pozycja jest wymagana")]
        [Display(Name = "Cena regularna")]
        [Range(1, 1000000, ErrorMessage = "Cena jest wymagana")]
        public double ListPrice { get; set; }

        [Required(ErrorMessage = "Ta pozycja jest wymagana")]
        [Display(Name = "Cena dla ilości 1-50")]
        [Range(1, 1000000, ErrorMessage = "Cena jest wymagana")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Ta pozycja jest wymagana")]
        [Display(Name = "Cena dla ilości 51-100")]
        [Range(1, 1000000, ErrorMessage = "Cena jest wymagana")]
        public double Price50 { get; set; }

        [Required(ErrorMessage = "Ta pozycja jest wymagana")]
        [Display(Name = "Cena dla ilości 100+")]
        [Range(1, 1000000, ErrorMessage = "Cena jest wymagana")]
        public double Price100 { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [Display(Name = "Kategoria")]
        [ValidateNever]
        public Category Category { get; set; }

        [ValidateNever]
        public string ImageUrl { get; set; }

    }
}

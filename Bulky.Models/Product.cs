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

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Autor")]
        public string Author { get; set; }

        [Required]
        [Display(Name = "Cena regularna")]
        [Range(1, 1000000)]
        public double ListPrice { get; set; }

        [Required]
        [Display(Name = "Cena dla ilości 1-50")]
        [Range(1,1000000)]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Cena dla ilości 51-100")]
        [Range(1, 1000000)]
        public double Price50 { get; set; }

        [Required]
        [Display(Name = "Cena dla ilości 100+")]
        [Range(1, 1000000)]
        public double Price100 { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        [ValidateNever]
        public string ImageUrl { get; set; }

    }
}

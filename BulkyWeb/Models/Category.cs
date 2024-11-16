﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [Required]
        [Range(1,100,ErrorMessage = "Display Order powinien wynosić między 1-100")]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
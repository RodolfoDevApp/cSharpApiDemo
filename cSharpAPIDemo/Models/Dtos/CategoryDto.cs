using System;
using System.ComponentModel.DataAnnotations;

namespace cSharpAPIDemo.Models.Dtos

{
    public class CategoryDto
    {
        public int id { get; set; }
        [Required(ErrorMessage ="The name is required")]
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
    }
}

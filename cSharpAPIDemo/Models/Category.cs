using System;
using System.ComponentModel.DataAnnotations;

namespace cSharpAPIDemo.Models
{
    public class Category
    {
        [Key]
        public int id { get; set; }
        
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
    }
}

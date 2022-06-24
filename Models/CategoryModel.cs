using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iTECH_Application.Models
{
    public class CategoryModel
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "*Category cannot be blank")]
        public string category { get; set; }
    }
}

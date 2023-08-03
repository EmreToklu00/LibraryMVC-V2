using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace library.webui.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [Display(Name = "Name", Prompt = "Enter Category Name")]
        [Required(ErrorMessage = "Category Name Is Required")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Category Name Length Must Be 5-100 Character")]
        public string Name { get; set; }

        [Display(Name = "Url", Prompt = "Enter Category Url")]
        [Required(ErrorMessage = "Category Url Is Required")]
        public string Url { get; set; }
        public List<Book> Books { get; set; }
    }
}
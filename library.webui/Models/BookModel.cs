using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace library.webui.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Display(Name = "Name", Prompt = "Enter Book Name")]
        [Required(ErrorMessage = "Book Name Is Required Field")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Book Name Minimum Length Must Be 5 Character")]
        public string Name { get; set; }
        [Display(Name = "Url", Prompt = "Enter Book Url")]
        [Required(ErrorMessage = "Book Url Is Required Field")]
        public string Url { get; set; }

        [Display(Name = "Price", Prompt = "Enter Book Price")]
        [Required(ErrorMessage = "Book Price Is Required Field")]
        [Range(1, 100000, ErrorMessage = "Book Price's Must Be 1-100000")]
        public double? Price { get; set; }

        [Display(Name = "Description", Prompt = "Enter Book Description")]
        [Required(ErrorMessage = "Book Description Is Required Field")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Book Description Length Must Be 5-100 Character")]
        public string Description { get; set; }

        [Display(Name = "ImageUrl", Prompt = "Enter Book ImageUrl")]
        [Required(ErrorMessage = "Book ImageUrl Is Required Field")]
        public string ImageUrl { get; set; }

        public int? CategoryId { get; set; }

        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }

        public List<Category> SelectedCategories { get; set; }
    }
}
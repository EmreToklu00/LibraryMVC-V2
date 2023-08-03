using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library.webui.Models
{
    public class BookDetailModel
    {
        public Book book { get; set; }

        public List<Category> categories { get; set; }
    }
}
using System;
using System.Collections.Generic;


namespace library.webui.Models
{

    public class PageInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public string CurrentCategory { get; set; }
        public int TotalPages()
        {
            return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
        }
    }


    public class BookListViewModel
    {

        public PageInfo PageInfo { get; set; }
        public List<Book> books { get; set; }

    }
}
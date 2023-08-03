using System.Collections.Generic;
using library.entity;

public class Book
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }

    public double Price { get; set; }

    public string Description { get; set; }

    public string ImageUrl { get; set; }

    public int? CategoryId { get; set; }

    public bool IsApproved { get; set; }
    public bool IsHome { get; set; }

    public List<BookCategory> BookCategories { get; set; }

}
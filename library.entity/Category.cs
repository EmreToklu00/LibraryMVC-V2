
using System.Collections.Generic;
using library.entity;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public List<BookCategory> BookCategories { get; set; }

}
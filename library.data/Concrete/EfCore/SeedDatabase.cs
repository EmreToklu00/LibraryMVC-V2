using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library.entity;
using Microsoft.EntityFrameworkCore;

namespace library.data.Concrete.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new BookContext();

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Categories.Count() == 0)
                {
                    context.Categories.AddRange(categories);
                }
                if (context.Books.Count() == 0)
                {
                    context.Books.AddRange(books);
                    context.AddRange(bookCategories);
                }
            }
            context.SaveChanges();
        }
        private static Category[] categories
        ={
            new Category(){Name="Macera",Url="macera"},
            new Category(){Name="Fantastic",Url="fantastic"},
            new Category(){Name="Roman",Url="roman"},
        };

        private static String randomImageUrl1 = "1.jpg";
        private static String randomImageUrl2 = "3.jpg";
        private static String randomImageUrl3 = "4.jpg";

        private static Book[] books ={
            new Book(){
                Name="Macera Kitabı test 1",
                Url="macera-kitabı-test-1",
                CategoryId=1,
                Price=250,
                Description="macera ile ilgili güzel bir kitap",
                ImageUrl=randomImageUrl1,
                IsApproved=true,
                IsHome=false,
            },
            new Book(){
                Name="Macera Kitabı test 2",
                Url="macera-kitabı-test-2",
                Price=250,
                Description="macera ile ilgili güzel bir kitap 2",
                ImageUrl=randomImageUrl2,
                  IsApproved=false,
                IsHome=true,

            },
            new Book(){
                Name="Fantastic Kitabı test 1",
                Url="fantastic-kitabı-test-1",
                CategoryId=2,
                Price=350,
                Description="Fantastic tür ile ilgili güzel bir kitap",
                ImageUrl=randomImageUrl3,
                  IsApproved=true,
                IsHome=true,

            },
            new Book(){
                Name="Roman Kitabı test 1",
                Url="roman-kitabı-test-1",
                CategoryId=3,
                Price=450,
                Description="Roman ile ilgili güzel bir kitap",
                ImageUrl=randomImageUrl2,
                  IsApproved=true,
                IsHome=false,
            },
             new Book(){
                Name="Roman Kitabı test 2",
                Url="roman-kitabı-test-2",
                CategoryId=3,
                Price=450,
                Description="Roman ile ilgili güzel bir kitap 2",
                ImageUrl=randomImageUrl3,
                  IsApproved=true,
                IsHome=true,
            }, new Book(){
                Name="Roman Kitabı test 3",
                Url="roman-kitabı-test-3",
                CategoryId=3,
                Price=450,
                Description="Roman ile ilgili güzel bir kitap 3",
                ImageUrl=randomImageUrl1,
                  IsApproved=false,
                IsHome=false,
            }, new Book(){
                Name="Roman Kitabı test 4",
                Url="roman-kitabı-test-4",
                CategoryId=3,
                Price=450,
                Description="Roman ile ilgili güzel bir kitap 4",
                ImageUrl=randomImageUrl2,
                IsApproved=false,
                IsHome=true,
            },
        };
        private static BookCategory[] bookCategories = {
            new BookCategory(){Book=books[0],Category=categories[0]},
            new BookCategory(){Book=books[0],Category=categories[2]},
            new BookCategory(){Book=books[1],Category=categories[1]},
            new BookCategory(){Book=books[1],Category=categories[2]},
            new BookCategory(){Book=books[2],Category=categories[0]},
            new BookCategory(){Book=books[2],Category=categories[1]},
            new BookCategory(){Book=books[3],Category=categories[2]},
            new BookCategory(){Book=books[4],Category=categories[0]},
            new BookCategory(){Book=books[5],Category=categories[0]},
            new BookCategory(){Book=books[6],Category=categories[1]},
            new BookCategory(){Book=books[6],Category=categories[2]},
            new BookCategory(){Book=books[6],Category=categories[0]},
        };
    }
}
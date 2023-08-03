using System.IO;
using library.business.Abstract;
using library.business.Concrete;
using library.data.Abstract;
using library.data.Concrete.EfCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace library.webui
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IBookRepository, EfCoreBookRepository>();
            services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();

            services.AddScoped<IBookService, BookManager>();
            services.AddScoped<ICategoryService, CategoryManager>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                   Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
                RequestPath = "/modules"
            });


            if (env.IsDevelopment())
            {
                SeedDatabase.Seed();
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //admin/book
                endpoints.MapControllerRoute(
                 name: "adminbooks",
                 pattern: "admin/books",
                 defaults: new { controller = "Admin", action = "BookList" }
                );
                endpoints.MapControllerRoute(
                name: "adminbookcreate",
                pattern: "admin/books/create",
                defaults: new { controller = "Admin", action = "BookCreate" }
                );
                endpoints.MapControllerRoute(
                 name: "adminbookedit",
                 pattern: "admin/books/{id?}",
                 defaults: new { controller = "Admin", action = "BookEdit" }
                );
                //
                //admin/category
                endpoints.MapControllerRoute(
                 name: "admincategories",
                 pattern: "admin/categories",
                 defaults: new { controller = "Admin", action = "CategoryList" }
                );
                endpoints.MapControllerRoute(
                 name: "admincategorycreate",
                 pattern: "admin/categories/create",
                 defaults: new { controller = "Admin", action = "CategoryCreate" }
                );
                endpoints.MapControllerRoute(
                name: "admincategoryedit",
                pattern: "admin/categories/{id?}",
                defaults: new { controller = "Admin", action = "CategoryEdit" }
                );
                //
                endpoints.MapControllerRoute(
                   name: "search",
                   pattern: "search",
                   defaults: new { controller = "Library", action = "Search" }
               );

                endpoints.MapControllerRoute(
                    name: "bookdetails",
                    pattern: "{url}",
                    defaults: new { controller = "Library", action = "details" }
                );

                endpoints.MapControllerRoute(
                    name: "books",
                    pattern: "books/{category?}",
                    defaults: new { controller = "Library", action = "List" }
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}

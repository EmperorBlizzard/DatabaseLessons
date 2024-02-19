using EM_EntityFramework.Contexts;
using EM_EntityFramework.Models;
using EM_EntityFramework.Repositories;
using EM_EntityFramework.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace EM_EntityFramework
{
    internal class Program
    {
        private static readonly string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Skola\Database\Lessons\Lektion-5\EM_EntityFramework\Contexts\EM_database.mdf;Integrated Security=True;Connect Timeout=30";
        static async Task Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddDbContext<DataContext>(x => x.UseSqlServer(connectionstring));
                    services.AddScoped<SubCategoryRepository>();
                    services.AddScoped<PrimaryCategoryRepository>();
                    services.AddScoped<ProductRepository>();
                    services.AddScoped<ProductService>();
                }).Build();

            using (var scope = builder.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var productService  = services.GetRequiredService<ProductService>();
                var productRegistration = new ProductRegistration
                {
                    ArticleNumber = Guid.NewGuid().ToString(),
                    Name = "Product ",
                    Description = "Description",
                    Price = 100,
                    SubCategoryName = "Stationär",
                    PrimaryCategoryName = "Datorer"

                };
                var result = await productService.CreateProductAsync(productRegistration);

                var json = JsonConvert.SerializeObject(result, new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

                Console.WriteLine(json);
                Console.ReadKey();
            }

            await builder.RunAsync();

            builder.Run();
        }
    }
}
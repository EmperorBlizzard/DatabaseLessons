using Assignment.Contexts;
using Assignment.Menus;
using Assignment.Repostitories;
using Assignment.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddDbContext<DataContext>(options => options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Skola\Database\Lessons\Lektion-8\Assignment\Contexts\assignment_database.mdf;Integrated Security=True;Connect Timeout=30"));
            services.AddScoped<AddressRepository>();
            services.AddScoped<CustomserRepository>();

            services.AddScoped<CustomerService>();

            services.AddScoped<MainMenu>();
            services.AddScoped<CustomerMenu>();


            var sp = services.BuildServiceProvider();
            var mainMenu = sp.GetRequiredService<MainMenu>();

            await mainMenu.StartAsync();

        }
    }
}
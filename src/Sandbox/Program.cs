using System;
using System.Linq;
using System.IO;
using System.IO.Compression;
using AngleSharp;
using CommandLine;
using FitnessGuru.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sandbox
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"{typeof(Program).Namespace} ({string.Join(" ", args)}) starts working...");
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider(true);

            using (var serviceScope = serviceProvider.CreateScope())
            {
                serviceProvider = serviceScope.ServiceProvider;
                SandboxCode(serviceProvider);
            }
        }

        private static void SandboxCode(IServiceProvider serviceProvider)
        {
            //var config = Configuration.Default.WithDefaultLoader();
            //var context = BrowsingContext.New(config);
            //for (int i = 1; i < 300; i++)
            //{
            //    var url = "" + i;
            //    var document = context.OpenAsync(url).GetAwaiter().GetResult();
            //   var articleContent= document.QuerySelector("").TextContent;
            //    var categoryName = document.QuerySelector();
            //}
          
            //var cells = document.QuerySelector("");


        }

        private static void ConfigureServices(ServiceCollection serviceCollection)
        {

            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables()
                .Build();

            serviceCollection.AddDbContext<FitnessGuruWebContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
        }

    }
}
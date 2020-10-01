using Microsoft.Extensions.DependencyInjection;
using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.ApplicationService.Services;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using PetShopApp.Infrastructure.Static.Data.Repositories;
using System;

namespace PetShopApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPrinter, Printer>();

            var serviceProvicer = serviceCollection.BuildServiceProvider();
            var printer = serviceProvicer.GetRequiredService<IPrinter>();
            printer.StartUI();
        }
    }
}

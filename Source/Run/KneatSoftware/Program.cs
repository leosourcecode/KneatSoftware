using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Services;
using Contracts.Domain;
using Infrastructure.ExtensionMethods;
using Microsoft.Extensions.DependencyInjection;

namespace KneatSoftware
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to Star Wars Calculator!");
            Console.WriteLine(string.Empty);

            ConfigureIoC();

            bool continues;
            do
            {

                Console.WriteLine("Enter the distance in mega lights (MGLT):");

                var distance = Console.ReadLine();

                var distanceInMglt = distance.IsValidValue() ? distance.GetMegaLightsFromString() : 1000000;

                Console.WriteLine(string.Empty);
                Console.WriteLine($"Distance in MGLT: {distanceInMglt}");
                Console.WriteLine(string.Empty);

                var starshipService = _serviceProvider.GetService<IStarshipService>();

                var starships = await starshipService.GetAllStarshipsAsync(distanceInMglt);

                ShowStarShips(starships);

                Console.WriteLine("Would you like to continue?");
                Console.WriteLine("Press [Y] or [N]");
                var option = Console.ReadLine();
                continues = option.ToLower() == "y";

            } while (continues);
        }

        static void ShowStarShips(IEnumerable<Starship> starships)
        {
            Console.WriteLine("------------------------------------------------------");

            foreach (var starship in starships)
            {
                Console.WriteLine($"===> Name: {starship.Name}");
                Console.WriteLine($"     Model: {starship.Model}");
                Console.WriteLine($"     Manufacturer: {starship.Manufacturer}");
                Console.WriteLine($"     MGLT: {starship.MGLT}");
                Console.WriteLine($"     Stops: {starship.Stops}");
                Console.WriteLine(string.Empty);
            }

            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine(string.Empty);
            Console.WriteLine("May the Force be with you!");
        }

        static void ConfigureIoC()
        {
            // Getting Services from IoC
            var services = new Infrastructure.IoC.Services();

            var collection = new ServiceCollection();

            // Building Services
            services.Configure(collection);

            _serviceProvider = collection.BuildServiceProvider();
        }
    }
}

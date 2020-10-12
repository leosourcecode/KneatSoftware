using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace IntegrationTests.Configuration
{
    /// <summary>
    /// Collection will apply for all test class that are member of this collection. You have to declare this collection
    /// as attribute of the Test Class
    /// </summary>
    [CollectionDefinition(nameof(IntegrationTestConfigurationCollection))]
    public class IntegrationTestConfigurationCollection : ICollectionFixture<IntegrationTestConfiguration> { }

    /// <summary>
    /// This fixture created once the instance of objects and it does not call for each test that starts, 
    /// because it saves the state of the object.
    /// </summary>    
    public class IntegrationTestConfiguration
    {

        public readonly IStarshipService _starshipService;

        public IntegrationTestConfiguration()
        {
            // Getting Services from IoC
            var services = new Infrastructure.IoC.Services();

            var collection = new ServiceCollection();

            // Building Services
            services.Configure(collection);

            var serviceProvider = collection.BuildServiceProvider();
            _starshipService = serviceProvider.GetService<IStarshipService>();
        }

        public int GetDistanceInMegaLights() => 1000000;
    }
}

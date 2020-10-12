using Application.Builders;
using Application.Helpers;
using Application.Services;
using Application.TimeCalculators;
using Infrastructure.Builders;
using Infrastructure.Factories;
using Infrastructure.Helpers;
using Infrastructure.Services;
using Infrastructure.TimeCalculation;
using Infrastructure.TimeCalculators;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC
{
    /// <summary>
    /// IoC Setup
    /// </summary>
    public class Services
    {
        /// <summary>
        /// Configure dependency injection
        /// </summary>
        /// <param name="services"></param>
        public void Configure(IServiceCollection services)
        {
            // Add Builders
            services.AddTransient<IKneatSoftwareUrlBuilder, KneatSoftwareUrlBuilder>();

            // Add Helpers
            services.AddTransient<IHttpClient, HttpClient>();

            // Add Factories
            services.AddTransient<HoursCalculatorFactory>();

            // Add TimeCalculators
            services.AddTransient<IHours, Hours>();
            services.AddTransient<IHoursCalculator, HoursByDayCalculator>()
                    .AddTransient<IHoursCalculator, HoursByMonthCalculator>()
                    .AddTransient<IHoursCalculator, HoursByWeekCalculator>()
                    .AddTransient<IHoursCalculator, HoursByYearCalculator>()
                    .AddTransient<IHoursCalculator, UnknowTimeCalculator>();

            // Add Services 
            services.AddTransient<IMegaLightsCalculatorService, MegaLightsCalculatorService>();
            services.AddTransient<IStarshipService, StarshipService>();
            services.AddTransient<ICosumablesService, CosumablesService>();
        }
    }
}

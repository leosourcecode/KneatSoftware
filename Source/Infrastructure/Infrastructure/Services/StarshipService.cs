using Application.Builders;
using Application.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Domain;
using Newtonsoft.Json;
using Application.Services;

namespace Infrastructure.Services
{
    public class StarshipService : IStarshipService
    {
        private readonly IHttpClient _httpClient;
        private readonly IKneatSoftwareUrlBuilder _kneatSoftwareUrlBuilder;
        private readonly IMegaLightsCalculatorService _megaLightsCalculatorService;

        public StarshipService(IHttpClient httpClient, IKneatSoftwareUrlBuilder kneatSoftwareUrlBuilder, IMegaLightsCalculatorService megaLightsCalculatorService)
        {
            _httpClient = httpClient;
            _kneatSoftwareUrlBuilder = kneatSoftwareUrlBuilder;
            _megaLightsCalculatorService = megaLightsCalculatorService;
        }

        /// <summary>
        /// Get all Starships
        /// </summary>
        /// <param name="distanceInMegaLights">Distance in MegaLights</param>
        /// <returns>A list with the Starships</returns>
        public async Task<IEnumerable<Starship>> GetAllStarshipsAsync(double distanceInMegaLights)
        {
            // Get the api Url to be used to call the StarWars API
            var url = _kneatSoftwareUrlBuilder.GetAllStarshipsApiUrl();

            var starships = new List<Starship>();
            var apiResponse = new StarWarsApiResponse();

            // Getting the Starships
            do
            {
                apiResponse = JsonConvert.DeserializeObject<StarWarsApiResponse>(await _httpClient.GetAsync(url));
                starships.AddRange(apiResponse.Results);
                url = apiResponse?.Next;
            } while (apiResponse.Next != null);

            // Adding the number of stops to the Starships
            AddStopsToStartships(distanceInMegaLights, starships);

            return starships;
        }

        private void AddStopsToStartships(double distanceInMegaLights, List<Starship> starships)
        {
            foreach (var starship in starships)
            {
                starship.AddStops(_megaLightsCalculatorService.CalculateStopsByDistance(distanceInMegaLights, starship.MGLT, starship.Consumables));
            }
        }
    }
}

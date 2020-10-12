using Application.Services;
using Infrastructure.ExtensionMethods;
using System;

namespace Infrastructure.Services
{
    public class MegaLightsCalculatorService : IMegaLightsCalculatorService
    {
        private readonly ICosumablesService _cosumablesService;

        public MegaLightsCalculatorService(ICosumablesService cosumablesService)
        {
            _cosumablesService = cosumablesService;
        }

        /// <summary>
        /// Will calculate the number of stops that is necessary for the distance
        /// </summary>
        /// <param name="distanceInMegaLights">Distance in MegaLights</param>
        /// <param name="consumables">Consumables</param>
        /// <param name="megaLights">MegaLights</param>
        /// <returns>Stops</returns>
        public double CalculateStopsByDistance(double distanceInMegaLights, string megaLights, string consumables)
        {           
            if (consumables == "unknown" || string.IsNullOrEmpty(consumables) || !megaLights.IsValidValue()) return 0;

            var hours = CalculateHours(distanceInMegaLights, megaLights.GetMegaLightsFromString());
            var consumablesHours = ConvertCosumablesToHours(consumables);
            var stops = consumablesHours == 0 ? consumablesHours : hours / consumablesHours;

            return Math.Floor(stops);
        }

        /// <summary>
        /// Convert cosumables to hours
        /// </summary>
        /// <param name="consumables">Consumables</param>
        /// <returns>Consumables Hours</returns>
        private double ConvertCosumablesToHours(string consumables)
        {
            var consumablesArray = consumables.Split(' ');
            var consumableValue = Convert.ToDouble(consumablesArray[0]);
            var time = consumablesArray[1];

            return _cosumablesService.CalculateConsumableInHours(consumableValue, time);
        }

        /// <summary>
        /// Calculate the hours by distance and MegaLights
        /// </summary>
        /// <param name="distanceInMegaLights">Distance in MegaLights</param>
        /// <param name="megaLights"></param>
        /// <returns>The hours</returns>
        private double CalculateHours(double distanceInMegaLights, double megaLights)
        {
            return distanceInMegaLights / megaLights;
        }
    }
}

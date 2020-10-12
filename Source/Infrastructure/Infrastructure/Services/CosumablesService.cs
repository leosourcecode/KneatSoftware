using Application.Services;
using Infrastructure.Factories;

namespace Infrastructure.Services
{
    public class CosumablesService : ICosumablesService
    {
        private readonly HoursCalculatorFactory _hoursCalculatorFactory;

        public CosumablesService(HoursCalculatorFactory hoursCalculatorFactory)
        {
            _hoursCalculatorFactory = hoursCalculatorFactory;
        }

        /// <summary>
        /// Calculate the consumable to hours
        /// </summary>
        /// <param name="consumables">Consumables</param>
        /// <param name="time">Time</param>
        /// <returns>Hours</returns>
        public double CalculateConsumableInHours(double consumableValue, string time)
        {
            return (_hoursCalculatorFactory.GetTimeCalculator(time).CalculateHours()) * consumableValue;
        }
    }
}

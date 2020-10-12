using Application.TimeCalculators;
using System;

namespace Infrastructure.TimeCalculators
{
    public class Hours : IHours
    {
        /// <summary>
        /// Get hours based on the day
        /// </summary>
        /// <param name="days">Number of days</param>
        /// <returns>double</returns>
        public double Get(int days)
        {
            return new TimeSpan(days, 0, 0, 0).TotalHours;
        }            
    }
}

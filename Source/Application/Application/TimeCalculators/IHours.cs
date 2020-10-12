namespace Application.TimeCalculators
{
    /// <summary>
    /// Get the hours
    /// </summary>
    public interface IHours
    {
        /// <summary>
        /// Get hours based on the day
        /// </summary>
        /// <param name="days">Number of days</param>
        /// <returns>double</returns>
        double Get(int days);
    }
}

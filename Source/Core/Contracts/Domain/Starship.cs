namespace Contracts.Domain
{
    /// <summary>
    /// Class that represents a Starship
    /// </summary>
    public class Starship
    {
        public string Name { get; set; }
        public string Consumables { get; set; }
        public string MGLT { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public double Stops { get; protected set; }

        /// <summary>
        /// Add the number of stops for the Starship
        /// </summary>
        /// <param name="stops">The number of stops for the Starship</param>
        public void AddStops(double stops) => Stops = stops;
    }
}

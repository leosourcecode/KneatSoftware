using System.Collections.Generic;

namespace Contracts.Domain
{
    /// <summary>
    /// Class that represents the response from Star Wars API
    /// </summary>
    public class StarWarsApiResponse
    {
        public string Next { get; set; }
        public List<Starship> Results { get; set; }
    }
}

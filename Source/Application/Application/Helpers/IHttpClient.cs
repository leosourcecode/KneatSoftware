using System.Threading.Tasks;

namespace Application.Helpers
{
    /// <summary>
    /// Helper to make calls for API
    /// </summary>
    public interface IHttpClient
    {
        /// <summary>
        /// Call API using GET
        /// </summary>
        /// <param name="url">Url to be used to call the API</param>
        /// <returns>A string with the result</returns>
        Task<string> GetAsync(string url);
    }
}

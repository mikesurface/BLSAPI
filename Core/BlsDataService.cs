using CPIService.Model;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace CPIService.Core
{
    public class BlsDataService
    {
        #region Contructor and Globals

        private readonly IMemoryCache _cache;
        private readonly IHttpClientFactory _httpClientFactory;

        public BlsDataService(IMemoryCache cache, IHttpClientFactory httpClientFactory)
        {
            _cache = cache;
            _httpClientFactory = httpClientFactory;
        }

        #endregion

        public async Task<BlsApiResponse> GetBlsDataAsync(string seriesId)
        {
            var blsUri = AppSettings["BlsUri"];
            string apiUrl = $"{blsUri}/{seriesId}";

            // first, try to pull the data out of our in-memory cache
            if (_cache.TryGetValue(seriesId, out BlsApiResponse cachedData))
            {
                return cachedData;
            }

            // not in cache, so fetch, store and return a new dataset
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetStringAsync(apiUrl);

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<BlsApiResponse>(response, options);

            // cache our data for 24 hours for each seriesID requested
            _cache.Set(seriesId, data, TimeSpan.FromHours(24));

            return data;
        }
    }
}

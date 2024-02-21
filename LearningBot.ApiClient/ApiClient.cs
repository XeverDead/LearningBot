using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LearningBot.ApiClient;

internal class ApiClient
{
    private readonly HttpClient _httpClient = new();

    public async Task<T> Get<T>(string path) => await _httpClient.GetFromJsonAsync<T>(path);
}

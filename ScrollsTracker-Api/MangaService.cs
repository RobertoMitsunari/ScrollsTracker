using ScrollsTracker.Api.Model;
using ScrollsTracker.Api.Model.Response;
using System.Text.Json;

public class MangaService
{
    private readonly HttpClient _httpClient;

    public MangaService(HttpClient httpClient)
    {
        _httpClient = httpClient;

        if (!_httpClient.DefaultRequestHeaders.UserAgent.Any())
        {
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("ScrollsTracker/1.0 (localhost)");
        }
    }

    public async Task<MangaResponse?> ObterMangasAsync()
    {
        var url = "https://api.mangadex.org/manga";
        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Erro {response.StatusCode}: {error}");
        }

        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<MangaResponse>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
    public async Task<CoverResponse?> ObterCoversAsync(string mangaId)
    {
        var url = $"https://api.mangadex.org/cover?manga[]={mangaId}";
        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Erro {response.StatusCode}: {error}");
        }

        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<CoverResponse>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public async Task<ChapterResponse?> ObterCapitulosAsync(string mangaId)
    {
        var url = $"https://api.mangadex.org/chapter?manga={mangaId}&translatedLanguage[]=en";
        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Erro {response.StatusCode}: {error}");
        }

        var content = await response.Content.ReadAsStringAsync();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        return JsonSerializer.Deserialize<ChapterResponse>(content, options);
    }


}

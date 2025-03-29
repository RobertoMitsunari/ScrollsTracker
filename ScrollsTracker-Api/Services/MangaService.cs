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
        var url = $"https://api.mangadex.org/chapter?manga={mangaId}&translatedLanguage[]=en&order[chapter]=desc";
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

    public async Task<JsonDocument> BuscarMangasPorTituloAsync(string titulo)
    {
        var encodedTitle = Uri.EscapeDataString(titulo);
        var url = $"https://api.mangadex.org/manga?title={encodedTitle}&limit=1&includes[]=cover_art";
        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Erro {response.StatusCode}: {error}");
        }

        var content = await response.Content.ReadAsStringAsync();

        return JsonDocument.Parse(content);
    }

    public async Task PreencherDadosDaObra(Obra obra)
    {
        if (obra.Titulo is null)
            throw new Exception("Titulo não encontrado");

        var result = await BuscarMangasPorTituloAsync(obra.Titulo);
        JsonElement root = result.RootElement;

        foreach (JsonElement item in root.GetProperty("data").EnumerateArray())
        {
            string idExterno = item.GetProperty("id").GetString() ?? "";
            string title = item.GetProperty("attributes").GetProperty("title").GetProperty("en").GetString() ?? "";
            string descricao = item.GetProperty("attributes").GetProperty("description").GetProperty("en").GetString() ?? "";
            string imagem = $"{idExterno}/{ProcurarImagem(item)}";
            int ultimoCap = await ProcurarUltimoCapitulo(idExterno);

            obra.AtualizarDados(new Guid(idExterno), title, descricao, ultimoCap, imagem);
        }
    }

    private string ProcurarImagem(JsonElement jsonElements)
    {
        foreach(JsonElement item in jsonElements.GetProperty("relationships").EnumerateArray())
        {
            if (item.GetProperty("type").GetString() == "cover_art")
            {
                var atributos = item.GetProperty("attributes");

                return atributos.GetProperty("fileName").GetString() ?? "";
            }
        }

        return "";
    }

    private async Task<int> ProcurarUltimoCapitulo(string id)
    {
        var result = await ObterCapitulosAsync(id);

        if(result is null)
            return 0;

        var data = result?.Data.FirstOrDefault();

        if (data is not null)
        {
            if(Int32.TryParse(data.Attributes.Chapter, out int chapter))
                return chapter;
        }

        return 0;
    }
}

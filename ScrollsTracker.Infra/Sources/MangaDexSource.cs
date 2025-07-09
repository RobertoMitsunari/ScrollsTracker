using ScrollsTracker.Domain.Interfaces;
using ScrollsTracker.Domain.Models;
using ScrollsTracker.Infra.ExternalApis.DTO.MangaDex;
using System.Text.Json;

namespace ScrollsTracker.Infra.Sources
{
	public class MangaDexSource : IObraSource
	{
		public string SourceName => throw new NotImplementedException();
		private readonly HttpClient _httpClient;

		public MangaDexSource(HttpClient httpClient)
		{
			_httpClient = httpClient;
			if (!_httpClient.DefaultRequestHeaders.UserAgent.Any())
			{
				_httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("ScrollsTracker/1.0 (localhost)");
			}
		}

		public async Task<Obra?> ObterObraAsync(string titulo)
		{
			var search = await BuscarMangasPorTituloAsync(titulo);
			if (search == null || search.Data is null 
				|| search.Data.FirstOrDefault() is null 
				|| string.IsNullOrEmpty(search.Data.FirstOrDefault()!.Id)
				|| search.Data.FirstOrDefault()!.Attributes is null)
			{
				return null;
			}

			var capitulos = await ObterCapitulosAsync(search.Data.FirstOrDefault()!.Id);
			if (capitulos == null || capitulos.Data is null
				|| capitulos.Data.FirstOrDefault() is null
				|| string.IsNullOrEmpty(capitulos.Data.FirstOrDefault()!.Id)
				|| capitulos.Data.FirstOrDefault()!.Attributes is null)
			{
				return null;
			}

			var infoObra = search.Data.FirstOrDefault()!.Attributes;

			return new Obra
			{
				Titulo = titulo,
				Descricao = infoObra!.Description["en"],
				Status = infoObra.Status,
				TotalCapitulos = int.Parse(capitulos.Data.FirstOrDefault()!.Attributes!.Chapters)
			};
		}

		//TODO Imagem
		//public async Task<CoverResponse?> ObterCoversAsync(string mangaId)
		//{
		//	var url = $"https://api.mangadex.org/cover?manga[]={mangaId}";
		//	var response = await _httpClient.GetAsync(url);

		//	if (!response.IsSuccessStatusCode)
		//	{
		//		var error = await response.Content.ReadAsStringAsync();
		//		throw new Exception($"Erro {response.StatusCode}: {error}");
		//	}

		//	var content = await response.Content.ReadAsStringAsync();
		//	return JsonSerializer.Deserialize<CoverResponse>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
		//}

		public async Task<BaseMangaDexChapterResponse?> ObterCapitulosAsync(string mangaId)
		{
			var url = $"https://api.mangadex.org/manga/{mangaId}/feed?limit=1&order[chapter]=desc";
			var response = await _httpClient.GetAsync(url);

			if (!response.IsSuccessStatusCode)
			{
				var error = await response.Content.ReadAsStringAsync();
				throw new Exception($"Erro {response.StatusCode}: {error}");
			}

			var content = await response.Content.ReadAsStringAsync();

			return JsonSerializer.Deserialize<BaseMangaDexChapterResponse>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
		}

		public async Task<BaseMangaDexSearchResponse?> BuscarMangasPorTituloAsync(string titulo)
		{
			var encodedTitle = Uri.EscapeDataString(titulo);
			var url = $"https://api.mangadex.org/manga?title={encodedTitle}&limit=1";
			var response = await _httpClient.GetAsync(url);

			if (!response.IsSuccessStatusCode)
			{
				var error = await response.Content.ReadAsStringAsync();
				throw new Exception($"Erro {response.StatusCode}: {error}");
			}

			var content = await response.Content.ReadAsStringAsync();

			return JsonSerializer.Deserialize<BaseMangaDexSearchResponse>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
		}
	}
}

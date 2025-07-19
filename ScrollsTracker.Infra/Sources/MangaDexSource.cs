using ScrollsTracker.Domain.Enum;
using ScrollsTracker.Domain.Interfaces;
using ScrollsTracker.Domain.Models;
using ScrollsTracker.Infra.ExternalApis.DTO.MangaDex.Chapter;
using ScrollsTracker.Infra.ExternalApis.DTO.MangaDex.Cover;
using ScrollsTracker.Infra.ExternalApis.DTO.MangaDex.Search;
using System.Text.Json;

namespace ScrollsTracker.Infra.Sources
{
	public class MangaDexSource : IObraSource
	{
		public EnumSources SourceName => EnumSources.MangaDex;
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

			var id = ProcurarIdDaObraPorTituloERemoveOutrosResultados(search, titulo);
			
			if (string.IsNullOrEmpty(id))
			{
				return null;
			}

			var capitulos = await ObterCapitulosAsync(id);
			if (capitulos == null || capitulos.Data is null
				|| capitulos.Data.FirstOrDefault() is null
				|| string.IsNullOrEmpty(capitulos.Data.FirstOrDefault()!.Id)
				|| capitulos.Data.FirstOrDefault()!.Attributes is null)
			{
				return null;
			}

			var cover = await ObterCoverFileNameAsync(id);
			if (cover == null || cover.Data is null 
				|| cover.Data.FirstOrDefault() is null || cover.Data.FirstOrDefault()!.Attributes is null)
			{
				cover = null;
			}

			var infoObra = search.Data.FirstOrDefault()!.Attributes;

			return new Obra
			{
				Titulo = titulo,
				Descricao = infoObra!.Description["en"],
				Status = infoObra.Status,
				TotalCapitulos = int.Parse(capitulos.Data.FirstOrDefault()!.Attributes!.Chapters),
				Imagem = cover is not null ? MontarFileName(cover.Data.FirstOrDefault()!.Attributes!.FileName, id) : "",
			};
		}

		private string ProcurarIdDaObraPorTituloERemoveOutrosResultados(BaseMangaDexSearchResponse search, string titulo)
		{
			foreach (var item in search.Data!) 
			{
				if(item.Attributes is null)
				{
					continue;
				}

				item.Attributes.Title.TryGetValue("en" as string, out var title);
				if (title != null && title.Trim().Equals(titulo.Trim(), StringComparison.OrdinalIgnoreCase))
				{
					return item.Id;
				}

				search.Data.Remove(item);
			}

			return "";
		}

		private string MontarFileName(string fileName, string id)
		{
			return $"https://uploads.mangadex.org/covers/{id}/{fileName}.256.jpg"; // URL base para as imagens do MangaDex
		}

		public async Task<MangaDexCoverResponse?> ObterCoverFileNameAsync(string mangaId)
		{
			var url = $"https://api.mangadex.org/cover?manga[]={mangaId}";
			var response = await _httpClient.GetAsync(url);

			if (!response.IsSuccessStatusCode)
			{
				var error = await response.Content.ReadAsStringAsync();
				throw new Exception($"Erro {response.StatusCode}: {error}");
			}

			var content = await response.Content.ReadAsStringAsync();
			return JsonSerializer.Deserialize<MangaDexCoverResponse>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
		}

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
			var url = $"https://api.mangadex.org/manga?title={encodedTitle}&limit=3";
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

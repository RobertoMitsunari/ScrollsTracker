using ScrollsTracker.Domain.Models;
using System.Text.Json.Serialization;

namespace ScrollsTracker.Infra.ExternalApis.DTO.MangaUpdate
{
    public class SeriesResponse
    {
		[JsonPropertyName("series_id")]
		public long SeriesId { get; set; }

		[JsonPropertyName("title")]
		public string? Title { get; set; }

		[JsonPropertyName("description")]
		public string? Description { get; set; }

		[JsonPropertyName("image")]
		public SeriesImageResponse Image { get; set; }

		[JsonPropertyName("type")]
		public string? Type { get; set; }

		[JsonPropertyName("status")]
		public string? Status { get; set; }

		[JsonPropertyName("latest_chapter")]
		public int LatestChapter { get; set; }

		public Obra ToDomain()
		{
			return new Obra
			{
				Titulo = Title ?? string.Empty,
				Descricao = Description ?? string.Empty,
				Imagem = Image.Url.Original ?? string.Empty,
				TotalCapitulos = LatestChapter,
				Status = Status ?? string.Empty
			};
		}
	}
}

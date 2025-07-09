using System.Text.Json.Serialization;

namespace ScrollsTracker.Infra.ExternalApis.DTO.MangaUpdate
{
	public class MangaUpdateRecordResponse
	{
		[JsonPropertyName("series_id")]
		public long SeriesId { get; set; }

		[JsonPropertyName("title")]
		public string? Title { get; set; }
	}
}
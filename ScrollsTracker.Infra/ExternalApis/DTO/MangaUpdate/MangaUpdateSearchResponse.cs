using System.Text.Json.Serialization;

namespace ScrollsTracker.Infra.ExternalApis.DTO.MangaUpdate
{
    public class MangaUpdateSearchResponse
    {
		[JsonPropertyName("results")]
		public required IList<MangaUpdateResultsResponse> Results { get; set; }
	}
}

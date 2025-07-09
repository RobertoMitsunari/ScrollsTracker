using System.Text.Json.Serialization;

namespace ScrollsTracker.Infra.ExternalApis.DTO.MangaUpdate
{
    public class SearchResponse
    {
		[JsonPropertyName("results")]
		public required IList<ResultsResponse> Results { get; set; }
	}
}

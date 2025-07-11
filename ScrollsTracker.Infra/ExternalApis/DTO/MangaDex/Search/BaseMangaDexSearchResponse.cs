using System.Text.Json.Serialization;

namespace ScrollsTracker.Infra.ExternalApis.DTO.MangaDex.Search
{
    public class BaseMangaDexSearchResponse
    {
		[JsonPropertyName("data")]
		public List<MangaDexSearchDataResponse>? Data { get; set; }
	}
}

using System.Text.Json.Serialization;

namespace ScrollsTracker.Infra.ExternalApis.DTO.MangaDex.Cover
{
    public class MangaDexCoverResponse
    {
		[JsonPropertyName("data")]
		public List<MangaDexCoverDataResponse> Data { get; set; }
	}
}

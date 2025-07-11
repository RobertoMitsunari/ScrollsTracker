using System.Text.Json.Serialization;

namespace ScrollsTracker.Infra.ExternalApis.DTO.MangaDex.Search
{
	public class MangaDexSearchDataResponse
	{
		[JsonPropertyName("id")]
		public required string Id { get; set; }

		[JsonPropertyName("attributes")]
		public MangaDexSearchAttributesResponse? Attributes { get; set; }
	}
}

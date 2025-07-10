using System.Text.Json.Serialization;

namespace ScrollsTracker.Infra.ExternalApis.DTO.MangaDex
{
	public class MangaDexSearchDataResponse
	{
		[JsonPropertyName("id")]
		public required string Id { get; set; }

		[JsonPropertyName("attributes")]
		public MangaDexSearchAttributesResponse? Attributes { get; set; }
	}
}

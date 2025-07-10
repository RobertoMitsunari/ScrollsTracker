using System.Text.Json.Serialization;

namespace ScrollsTracker.Infra.ExternalApis.DTO.MangaDex
{
	public class MangaDexSearchAttributesResponse
	{
		[JsonPropertyName("title")]
		public Dictionary<string, string> Title { get; set; }

		[JsonPropertyName("description")]
		public Dictionary<string, string> Description { get; set; }

		[JsonPropertyName("status")]
		public string Status { get; set; }
	}
}

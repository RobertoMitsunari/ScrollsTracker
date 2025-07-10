using System.Text.Json.Serialization;

namespace ScrollsTracker.Infra.ExternalApis.DTO.MangaDex
{
    public class MangaDexChapterDataResponse
    {
		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("type")]
		public string Type { get; set; }

		[JsonPropertyName("attributes")]
		public MangaDexChapterAttributeResponse Attributes { get; set; }
    }
}

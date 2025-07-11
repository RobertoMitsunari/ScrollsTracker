using System.Text.Json.Serialization;

namespace ScrollsTracker.Infra.ExternalApis.DTO.MangaDex.Cover
{
    public class MangaDexCoverAttributesResponse
    {
		[JsonPropertyName("fileName")]
		public string FileName { get; set; }
	}
}

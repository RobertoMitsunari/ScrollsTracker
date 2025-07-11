using System.Text.Json.Serialization;

namespace ScrollsTracker.Infra.ExternalApis.DTO.MangaDex.Cover
{
    public class MangaDexCoverDataResponse
    {
		[JsonPropertyName("attributes")]
		public MangaDexCoverAttributesResponse Attributes { get; set; }
		
	}
}

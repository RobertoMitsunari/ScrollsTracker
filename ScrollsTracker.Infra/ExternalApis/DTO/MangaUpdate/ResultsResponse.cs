using System.Text.Json.Serialization;

namespace ScrollsTracker.Infra.ExternalApis.DTO.MangaUpdate
{
	public class ResultsResponse
	{
		[JsonPropertyName("record")]
		public required RecordResponse Record { get; set; }
	}
}
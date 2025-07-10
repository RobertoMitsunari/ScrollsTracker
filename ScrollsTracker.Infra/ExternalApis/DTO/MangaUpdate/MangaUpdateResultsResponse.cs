using System.Text.Json.Serialization;

namespace ScrollsTracker.Infra.ExternalApis.DTO.MangaUpdate
{
	public class MangaUpdateResultsResponse
	{
		[JsonPropertyName("record")]
		public required MangaUpdateRecordResponse Record { get; set; }
	}
}
using System.Text.Json.Serialization;

namespace ScrollsTracker.Infra.ExternalApis.DTO.MangaDex.Chapter
{
    public class BaseMangaDexChapterResponse
    {
		[JsonPropertyName("data")]
		public List<MangaDexChapterDataResponse>? Data { get; set; }
	}
}

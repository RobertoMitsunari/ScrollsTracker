using System.Text.Json.Serialization;

namespace ScrollsTracker.Infra.ExternalApis.DTO.MangaDex.Chapter
{
	public class MangaDexChapterAttributeResponse
    {
		[JsonPropertyName("title")]
		public string Title { get; set; }

		[JsonPropertyName("chapter")]
		public string Chapters { get; set; }
    }
}

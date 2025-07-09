using System.Text.Json.Serialization;

namespace ScrollsTracker.Infra.ExternalApis.DTO.MangaUpdate
{
    public class SeriesImageResponse
    {
		[JsonPropertyName("url")]
		public ImageUrl Url { get; set; }

		[JsonPropertyName("height")]
		public int Height { get; set; }

		[JsonPropertyName("width")]
		public int Width { get; set; }
	}

	public class ImageUrl
	{
		[JsonPropertyName("original")]
		public string Original { get; set; }

		[JsonPropertyName("thumb")]
		public string Thumb { get; set; }
	}
}

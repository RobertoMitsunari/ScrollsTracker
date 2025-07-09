using ScrollsTracker.Infra.ExternalApiModels.DTO.MangaDex.Data;

namespace ScrollsTracker.Infra.ExternalApiModels.DTO.MangaDex.Response
{
    public class ChapterResponse
    {
        public string Result { get; set; }
        public string Response { get; set; }
        public List<ChapterData> Data { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public int Total { get; set; }
    }
}

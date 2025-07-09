using ScrollsTracker.Infra.ExternalApiModels.DTO.MangaDex.Atributes;

namespace ScrollsTracker.Infra.ExternalApiModels.DTO.MangaDex.Data
{
    public class ChapterData
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public ChapterAttributes Attributes { get; set; }
        public List<Relationship> Relationships { get; set; }
    }

    public class ChapterAttributes
    {
        public string Title { get; set; }
        public string Volume { get; set; }
        public string Chapter { get; set; }
        public int Pages { get; set; }
        public string TranslatedLanguage { get; set; }
        public string Uploader { get; set; }
        public string ExternalUrl { get; set; }
        public int Version { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public string PublishAt { get; set; }
        public string ReadableAt { get; set; }
    }
}

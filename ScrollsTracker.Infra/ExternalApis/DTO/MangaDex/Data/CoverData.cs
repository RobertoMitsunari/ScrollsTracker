using ScrollsTracker.Infra.ExternalApiModels.DTO.MangaDex.Atributes;

namespace ScrollsTracker.Infra.ExternalApiModels.DTO.MangaDex.Data
{
    public class CoverData
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public CoverAttributes Attributes { get; set; }
        public List<Relationship> Relationships { get; set; }
    }

    public class CoverAttributes
    {
        public string Volume { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string Locale { get; set; }
        public int Version { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}

using ScrollsTracker.Infra.ExternalApiModels.DTO.MangaDex.Atributes;

namespace ScrollsTracker.Infra.ExternalApiModels.DTO.MangaDex.Data
{
    public class MangaData
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public MangaAttributes Attributes { get; set; }
        public List<Relationship> Relationships { get; set; }
    }
}

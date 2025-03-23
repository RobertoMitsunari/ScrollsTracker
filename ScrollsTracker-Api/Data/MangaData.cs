using ScrollsTracker.Api.Atributes;

namespace ScrollsTracker.Api.Data
{
    public class MangaData
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public MangaAttributes Attributes { get; set; }
        public List<Relationship> Relationships { get; set; }
    }
}

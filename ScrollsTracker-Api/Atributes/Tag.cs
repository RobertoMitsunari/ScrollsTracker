namespace ScrollsTracker.Api.Atributes
{
    public class Tag
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public TagAttributes Attributes { get; set; }
        public List<Relationship> Relationships { get; set; }
    }

    public class TagAttributes
    {
        public Dictionary<string, string> Name { get; set; }
        public Dictionary<string, string> Description { get; set; }
        public string Group { get; set; }
        public int Version { get; set; }
    }

    public class Relationship
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Related { get; set; }
        public Dictionary<string, object> Attributes { get; set; }
    }

}

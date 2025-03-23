namespace ScrollsTracker.Api.Atributes
{
    public class MangaAttributes
    {
        public Dictionary<string, string> Title { get; set; }
        public List<Dictionary<string, string>> AltTitles { get; set; }
        public Dictionary<string, string> Description { get; set; }
        public bool IsLocked { get; set; }
        public Dictionary<string, string> Links { get; set; }
        public string OriginalLanguage { get; set; }
        public string LastVolume { get; set; }
        public string LastChapter { get; set; }
        public string PublicationDemographic { get; set; }
        public string Status { get; set; }
        public int Year { get; set; }
        public string ContentRating { get; set; }
        public bool ChapterNumbersResetOnNewVolume { get; set; }
        public List<string> AvailableTranslatedLanguages { get; set; }
        public string LatestUploadedChapter { get; set; }
        public List<Tag> Tags { get; set; }
        public string State { get; set; }
        public int Version { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }

}

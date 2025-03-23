using ScrollsTracker.Api.Data;

namespace ScrollsTracker.Api.Model.Response
{
    public class CoverResponse
    {
        public string Result { get; set; }
        public string Response { get; set; }
        public List<CoverData> Data { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public int Total { get; set; }
    }
}

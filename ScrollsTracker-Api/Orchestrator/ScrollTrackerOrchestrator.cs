namespace ScrollsTracker.Api.Orchestrator
{
    public class ScrollTrackerOrchestrator
    {
        private readonly ILogger<ScrollTrackerOrchestrator> _logger;
        public ScrollTrackerOrchestrator(ILogger<ScrollTrackerOrchestrator> logger)
        {
            _logger = logger;
        }
        public async Task RunAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Scroll Tracker Orchestrator is running.");
            //var client = _clientFactory.CreateClient("MangaService");
            //var response = await client.GetAsync("https://localhost:5001/api/manga");
            //if (response.IsSuccessStatusCode)
            //{
            //    var content = await response.Content.ReadAsStringAsync();
            //    _logger.LogInformation(content);
            //}
            //else
            //{
            //    _logger.LogError("Error calling MangaService");
            //}
        }
    }
}

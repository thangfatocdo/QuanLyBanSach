using System.Net.Http.Json;

public class AiRecommendationClient
{
    private readonly HttpClient _http;
    public AiRecommendationClient(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("AIClient");
    }

    // Gọi retrain
    public async Task<bool> RetrainAsync()
    => (await _http.PostAsync("retrain", null)).IsSuccessStatusCode;

    // Gọi recommend
    public async Task<List<RecommendationDto>> RecommendAsync(int userId, int topN = 15)
        => await _http.GetFromJsonAsync<List<RecommendationDto>>($"recommend?userId={userId}&topN={topN}")
           ?? new List<RecommendationDto>();
}
public class RecommendationDto
{
    public int BookId { get; set; }
    public float Score { get; set; }
}
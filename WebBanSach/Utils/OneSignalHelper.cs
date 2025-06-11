using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

public static class OneSignalHelper
{
    private static readonly string AppId = "983fb972-1c5f-4bbd-8911-1bdd6c79c396";
    private static readonly string RestApiKey = "os_v2_app_ta73s4q4l5f33cirdpowy6odszdt6n6bsoxe2uvretp2hs5tk44ek4rweardhnzclioc7iljr6qrfnsay343pu7wtzreieycceq4bqi";

    public static async Task SendBroadcastAsync(string heading, string content)
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", RestApiKey);

        var payload = new
        {
            app_id = AppId,
            included_segments = new[] { "All" }, // ← Gửi đến tất cả người dùng đã đăng ký app
            headings = new { en = heading },
            contents = new { en = content }
        };

        var json = JsonSerializer.Serialize(payload);
        var response = await client.PostAsync("https://onesignal.com/api/v1/notifications",
            new StringContent(json, Encoding.UTF8, "application/json"));

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Push thất bại: {error}");
        }
    }
}

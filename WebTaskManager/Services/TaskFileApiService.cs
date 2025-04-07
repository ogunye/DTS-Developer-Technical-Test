namespace WebTaskManager.Services
{
    public class TaskFileApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public TaskFileApiService(HttpClient httpClient, string baseUrl)
        {
            _httpClient = httpClient;
            _baseUrl = baseUrl;
        }
    }
}

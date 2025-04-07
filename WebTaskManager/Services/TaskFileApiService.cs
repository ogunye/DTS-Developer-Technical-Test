using WebTaskManager.Models;

namespace WebTaskManager.Services
{
    public class TaskFileApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public TaskFileApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;

            //Read the base URL from appsettings.json
            bool useHttps = configuration.GetValue<bool>("AppSettings:UseHttps");
            _baseUrl = useHttps
                ? configuration["AppSettings:BaseUrlHttps"]
                : configuration["AppSettings:BaseUrlHttp"];
        }

        public async Task<List<TaskFile>> GetAllTasks()
        {
            return await _httpClient.GetFromJsonAsync<List<TaskFile>>($"{_baseUrl}/api/taskfile")
                ?? new List<TaskFile>();
        }

        public async Task<TaskFile?> GetTaskById(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<TaskFile>($"{_baseUrl}/api/taskfile/{id}");
        }

        public async Task<bool> CreateTask(TaskFile task)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/taskfile", task);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateTask(TaskFile task)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/api/taskfile/{task.Id}", task);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteTask(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/api/taskfile/{id}");
            return response.IsSuccessStatusCode;
        }

    }
}

using BlogApp.ClassLib.Model;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlogApp.Services
{
    public class UserService
    {

        private readonly HttpClient _httpClient;
        public UserService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public async Task<User> getUser(int userId)
        {
            return await _httpClient.GetFromJsonAsync<User>("api/User/" + userId);
        }
    }
}

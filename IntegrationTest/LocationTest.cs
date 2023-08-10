using Core.Entities;
using Newtonsoft.Json;
using Xunit.Abstractions;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace IntegrationTest;

public class LocationTest
{
    private HttpClient? _httpClient;
    private readonly ITestOutputHelper _testOutputHelper;
    
    public LocationTest(ITestOutputHelper testOutputHelper) => _testOutputHelper = testOutputHelper;
    // ------------------------------------------
    private class PatchDoc
    {
        public string? op { get; set; }
        public string? path { get; set; }
        public string? value { get; set; }
    }
    // ------------------------------------------
    private async Task Login()
    {
        _httpClient = new HttpClient();

        var user = new User
        {
            UserName = "matin",
            Password = "123"
        };
        
        var byteContent = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(user)));
        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var response = await _httpClient.PostAsync("https://localhost:44300/api/User/Login", byteContent);
        var result = await response.Content.ReadAsStringAsync();
        var resultJson = JObject.Parse(result);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", resultJson["value"]!.ToString());
    }
    // --------------------------------------------------------------------------------------------
    [Fact]
    public async Task Get_Locations()
    {
        _httpClient = new HttpClient();

        await Login();
        
        var response = await _httpClient.GetAsync($"https://localhost:44300/api/Location/Get?pageNumber=1&pageLimit=10");
        var result = await response.Content.ReadAsStringAsync();
        _testOutputHelper.WriteLine(result);
    }
    // --------------------------------------------------------------------------------------------
    [Fact]
    public async Task Register_Location()
    {
        _httpClient = new HttpClient();

        await Login();
        
        var location = new Location
        {
            Title = "abc",
            Address = "abc",
            LocationType = "abc",
            Geolocation = "abc"
        };

        var byteContent = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(location)));
        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        
        var response = await _httpClient.PostAsync("https://localhost:44300/api/Location/Register", byteContent);
        var result = await response.Content.ReadAsStringAsync();
        _testOutputHelper.WriteLine(result);
    }
    // --------------------------------------------------------------------------------------------
    [Fact]
    public async Task Update_Location()
    {
        _httpClient = new HttpClient();

        await Login();

        var update = new List<PatchDoc>
        {
            new()
            {
                op = "replace",
                path = "Title",
                value = "title2"
            }
        };

        var byteContent = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(update)));
        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        
        var response = await _httpClient.PatchAsync($"https://localhost:44300/api/Location/Update/{4}", byteContent);
        var result = await response.Content.ReadAsStringAsync();
        _testOutputHelper.WriteLine(result);
    }
    // --------------------------------------------------------------------------------------------
    [Fact]
    public async Task Delete_Location()
    {
        _httpClient = new HttpClient();

        await Login();

        var response = await _httpClient.DeleteAsync($"https://localhost:44300/api/Location/Delete/{4}");
        var result = await response.Content.ReadAsStringAsync();
        _testOutputHelper.WriteLine(result);
    }
}

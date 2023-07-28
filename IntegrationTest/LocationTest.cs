using Newtonsoft.Json;
using Xunit.Abstractions;
using Infrastructure.Models;
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
        public string? path { get; set; }
        public string? op { get; set; }
        public string? value { get; set; }
    }
    // ------------------------------------------
    private async Task Login()
    {
        _httpClient = new HttpClient();

        var user = new Users
        {
            UserName = "matin",
            Password = "123"
        };
        
        var byteContent = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(user)));
        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var response = await _httpClient.PostAsync("https://localhost:44300/api/User/Login", byteContent);
        var result = await response.Content.ReadAsStringAsync();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result);
    }
    // --------------------------------------------------------------------------------------------
    [Fact]
    public async Task Get_Locations()
    {
        _httpClient = new HttpClient();

        await Login();
        
        var response = await _httpClient.GetAsync($"https://localhost:44300/api/Location/Get/{1}/{3}");
        var result = await response.Content.ReadAsStringAsync();
        _testOutputHelper.WriteLine(result);
    }
    // --------------------------------------------------------------------------------------------
    [Fact]
    public async Task Register_Location()
    {
        _httpClient = new HttpClient();

        await Login();
        
        var location = new Locations
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
                path = "/Title",
                op = "replace",
                value = "bbb"
            }
        };

        var byteContent = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(update)));
        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        
        var response = await _httpClient.PatchAsync($"https://localhost:44300/api/Location/Update/{5}", byteContent);
        var result = await response.Content.ReadAsStringAsync();
        _testOutputHelper.WriteLine(result);
    }
    // --------------------------------------------------------------------------------------------
    [Fact]
    public async Task Delete_Location()
    {
        _httpClient = new HttpClient();

        await Login();

        var response = await _httpClient.DeleteAsync($"https://localhost:44300/api/Location/Delete/{5}");
        var result = await response.Content.ReadAsStringAsync();
        _testOutputHelper.WriteLine(result);
    }
}

using Newtonsoft.Json;
using Xunit.Abstractions;
using Infrastructure.Models;
using System.Net.Http.Headers;

namespace IntegrationTest;

public class UserTest
{
    private HttpClient? _httpClient;
    private readonly ITestOutputHelper _testOutputHelper;
    
    public UserTest(ITestOutputHelper testOutputHelper) => _testOutputHelper = testOutputHelper;
    // --------------------------------------------------------------------------------------------
    [Fact]
    public async Task Signup_With_Existing_Username()
    {
        _httpClient = new HttpClient();

        var user = new Users
        {
            UserName = "matin",
            Password = "12345"
        };

        var data = JsonConvert.SerializeObject(user);
        var buffer = System.Text.Encoding.UTF8.GetBytes(data);
        var byteContent = new ByteArrayContent(buffer);
        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        var response = await _httpClient.PostAsync("https://localhost:44300/api/User/Signup", byteContent);
        var result = await response.Content.ReadAsStringAsync();
        _testOutputHelper.WriteLine(result);
    }
    // --------------------------------------------------------------------------------------------
    [Fact]
    public async Task Login_With_Invalid_Username_or_Password()
    {
        _httpClient = new HttpClient();

        var user = new Users
        {
            UserName = "matin",
            Password = "12345"
        };
        
        var data = JsonConvert.SerializeObject(user);
        var buffer = System.Text.Encoding.UTF8.GetBytes(data);
        var byteContent = new ByteArrayContent(buffer);
        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        
        var response = await _httpClient.PostAsync("https://localhost:44300/api/User/Login", byteContent);
        var result = await response.Content.ReadAsStringAsync();
        _testOutputHelper.WriteLine(result);
    }
    // --------------------------------------------------------------------------------------------
    [Fact]
    public async Task Login_With_valid_Username_and_Password()
    {
        _httpClient = new HttpClient();

        var user = new Users
        {
            UserName = "matin",
            Password = "123"
        };
        
        var data = JsonConvert.SerializeObject(user);
        var buffer = System.Text.Encoding.UTF8.GetBytes(data);
        var byteContent = new ByteArrayContent(buffer);
        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        
        var response = await _httpClient.PostAsync("https://localhost:44300/api/User/Login", byteContent);
        var result = await response.Content.ReadAsStringAsync();
        _testOutputHelper.WriteLine(result);
    }
}

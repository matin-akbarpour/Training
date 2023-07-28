using Newtonsoft.Json;
using Xunit.Abstractions;
using Infrastructure.Models;
using System.Net.Http.Headers;

namespace IntegrationTest;

public class ReservationTest
{
    private HttpClient? _httpClient;
    private readonly ITestOutputHelper _testOutputHelper;
    
    public ReservationTest(ITestOutputHelper testOutputHelper) => _testOutputHelper = testOutputHelper;
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
    public async Task Get_Reservations()
    {
        _httpClient = new HttpClient();

        await Login();

        var response = await _httpClient.GetAsync($"https://localhost:44300/api/Reservation/Get");
        var result = await response.Content.ReadAsStringAsync();
        _testOutputHelper.WriteLine(result);
    }
    // --------------------------------------------------------------------------------------------
    [Fact]
    public async Task Register_Reservation()
    {
        _httpClient = new HttpClient();

        await Login();
        
        var reservation = new Reservations
        {
            LocationID = 1,
            ReservationDate = Convert.ToDateTime("2023-07-03")
        };

        var byteContent = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(reservation)));
        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        
        var response = await _httpClient.PostAsync("https://localhost:44300/api/Reservation/Register", byteContent);
        var result = await response.Content.ReadAsStringAsync();
        _testOutputHelper.WriteLine(result);
    }
}

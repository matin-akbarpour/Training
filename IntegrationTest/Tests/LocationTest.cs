using System.Net.Http.Headers;
using Core.Entities;
using IntegrationTest.HttpHelper;
using IntegrationTest.Models;
using Newtonsoft.Json;
using Xunit.Abstractions;

namespace IntegrationTest.Tests;

public class LocationTest
{
    private readonly BaseClass _baseClass;
    private readonly ITestOutputHelper _testOutputHelper;

    public LocationTest(ITestOutputHelper testOutputHelper)
    {
        _baseClass =  new BaseClass();
        _testOutputHelper = testOutputHelper;
    }
    // ------------------------------------------
    private async Task Login(string userName, string password)
    {
        var user = new
        {
            UserName = userName,
            Password = password
        };
        
        var result = await _baseClass.PostAction<FluentResultVM<string>, object>("https://localhost:44300/api/User/Login", user);

        _baseClass.Authorization(result.value);
    }
    // --------------------------------------------------------------------------------------------
    [Fact]
    public async Task Get_Locations()
    {
        await Login("matin", "123");

        var result = await _baseClass.GetAction<FluentResultWithListVM<Location>>("https://localhost:44300/api/Location/Get", $"?pageNumber=1&pageLimit=10");
        
        _testOutputHelper.WriteLine(result.value[0].Address);
    }
    // --------------------------------------------------------------------------------------------
    [Fact]
    public async Task Register_Location()
    {
        await Login("matin", "123");

        var location = new
        {
            Title = "abc",
            Address = "abc",
            LocationType = "abc",
            Geolocation = "abc"
        };

        var result = await _baseClass.PostAction<FluentResultVM, object>("https://localhost:44300/api/Location/Register", location);
        
        _testOutputHelper.WriteLine(result.reasons[0].message);
    }
    // --------------------------------------------------------------------------------------------
    [Fact]
    public async Task Update_Location()
    {
        await Login("matin", "123");

        var update = new List<PatchDoc>
        {
            new()
            {
                op = "replace",
                path = "Title",
                value = "title2"
            }
        };

        var result = await _baseClass.PatchAction<FluentResultVM, object>("https://localhost:44300/api/Location/Update", update, $"/{5}");

        _testOutputHelper.WriteLine(result.reasons[0].message);
    }
    // --------------------------------------------------------------------------------------------
    [Fact]
    public async Task Delete_Location()
    {
        await Login("matin", "123");
    
        var result = await _baseClass.DeleteAction<FluentResultVM>("https://localhost:44300/api/Location/Delete", $"/{5}");
        
        _testOutputHelper.WriteLine(result.reasons[0].message);
    }
}

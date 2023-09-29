using Core.Entities;
using IntegrationTest.HttpHelper;
using IntegrationTest.Models;
using Xunit.Abstractions;

namespace IntegrationTest.Tests;

public class UserTest
{
    private readonly BaseClass _baseClass;
    private readonly ITestOutputHelper _testOutputHelper;

    public UserTest(ITestOutputHelper testOutputHelper)
    {
        _baseClass =  new BaseClass();
        _testOutputHelper = testOutputHelper;
    }
    // --------------------------------------------------------------------------------------------
    [Fact]
    public async Task Get_All_Users()
    {
        var result = await _baseClass.GetAction<FluentResultWithListVM<User>>("https://localhost:44300/api/User/Get");

        _testOutputHelper.WriteLine(result.value[0].UserName);
    }
    // --------------------------------------------------------------------------------------------
    [Fact]
    public async Task Signup_With_Existing_Username()
    {
        var user = new
        {
            UserName = "matin",
            Password = "12345"
        };

        var result = await _baseClass.PostAction<FluentResultVM, object>("https://localhost:44300/api/User/Signup", user);

        _testOutputHelper.WriteLine(result.reasons[0].message);
    }
    // --------------------------------------------------------------------------------------------
    [Fact]
    public async Task Login_With_Invalid_Username_or_Password()
    {
        var user = new
        {
            UserName = "matin",
            Password = "12345"
        };
        
        var result = await _baseClass.PostAction<FluentResultVM<string>, object>("https://localhost:44300/api/User/Login", user);

        _testOutputHelper.WriteLine(result.reasons[0].message);
    }
    // --------------------------------------------------------------------------------------------
    [Fact]
    public async Task Login_With_valid_Username_and_Password()
    {
        var user = new
        {
            UserName = "matin",
            Password = "123"
        };
        
        var result = await _baseClass.PostAction<FluentResultVM<string>, object>("https://localhost:44300/api/User/Login", user);

        _testOutputHelper.WriteLine(result.reasons[0].message);
        _testOutputHelper.WriteLine(result.value);
    }
}

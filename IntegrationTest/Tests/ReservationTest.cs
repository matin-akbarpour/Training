using Core.Entities;
using IntegrationTest.HttpHelper;
using IntegrationTest.Models;
using Xunit.Abstractions;

namespace IntegrationTest.Tests;

public class ReservationTest
{
    private readonly BaseClass _baseClass;
    private readonly ITestOutputHelper _testOutputHelper;

    public ReservationTest(ITestOutputHelper testOutputHelper)
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
    public async Task Get_Reservations()
    {
        await Login("matin", "123");
        
        var result = await _baseClass.GetAction<FluentResultWithListVM<Reservation>>("https://localhost:44300/api/Reservation/Get");

        _testOutputHelper.WriteLine(result.value[1].RegistrarUserName);
    }
    // --------------------------------------------------------------------------------------------
    [Fact]
    public async Task Register_Reservation()
    {
        await Login("matin", "123");
        
        var reservation = new
        {
            LocationId = 1,
            ReservationDate = Convert.ToDateTime("2001-01-01")
        };

        var result = await _baseClass.PostAction<FluentResultVM, object>("https://localhost:44300/api/Reservation/Register", reservation);

        _testOutputHelper.WriteLine(result.reasons[0].message);
    }
}

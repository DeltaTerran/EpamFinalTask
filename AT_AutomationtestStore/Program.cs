using AT_AutomationtestStore.Core;
using AT_AutomationtestStore.Models;
using AT_AutomationtestStore.PageObjects;
using AT_AutomationtestStore.PageObjects.Authorization;
var user1 = new UserRegistrationData
{
    FirstName = "John",
    LastName = "Smith",
    Email = $"john.smith.{Guid.NewGuid():N}@test.com",
    Address = "10 Main Street",
    City = "London",
    Country = "United Kingdom",
    Region = "Greater London",
    ZipCode = "SW1A1AA",
    Login = $"john{Guid.NewGuid():N}"[..15],
    Password = "Test12345"
};
DriverSingleton.Initialize(BrowserType.Chrome);
var IPage = new IndexPage(DriverSingleton.Instance);
IPage.Open().EnterloginOrRegisterPage().RegisterButtonClick().FillRegistrationForm(user1).SubmitRegistration().Continue();
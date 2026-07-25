using AT_AutomationtestStore.Core;
using AT_AutomationtestStore.Models;
using AT_AutomationtestStore.PageObjects;
using AT_AutomationtestStore.PageObjects.Authorization;
var user1 = new UserRegistrationData("John", "Smith", $"john.smith.{Guid.NewGuid():N}@test.com", "10 Main Street", "London", "Greater London", "SW1A1AA", "United Kingdom", $"john{Guid.NewGuid():N}"[..15], "Test12345");
DriverSingleton.Initialize(BrowserType.Chrome);
var IPage = new RegistrationPage(DriverSingleton.Instance);
var errorMessage = IPage.Open().SubmitWrongRegistration().getLoginErrorlabelText();
Console.WriteLine(errorMessage);
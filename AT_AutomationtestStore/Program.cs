using AT_AutomationtestStore.Core;
using AT_AutomationtestStore.PageObjects.Authorization;

DriverSingleton.Initialize(BrowserType.Chrome);

var page = new RegistrationPage(DriverSingleton.Instance);
var errorMessage = page.Open().Submit().GetLoginErrorLabelText();

Console.WriteLine(errorMessage);

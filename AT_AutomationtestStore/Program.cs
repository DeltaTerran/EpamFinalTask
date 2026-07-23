using AT_AutomationtestStore.Core;
using AT_AutomationtestStore.PageObjects;

DriverSingleton.Initialize(BrowserType.Chrome);
var IPage = new IndexPage(DriverSingleton.Instance);
IPage.Open().EnterloginOrRegisterPage().RegisterButtonClick();
using AT_AutomationtestStore.Models;
using AT_AutomationtestStore.PageObjects.Authorization;
using FluentAssertions;



namespace AT_AutomationtestStoreTest
{
    public class RegistrationTests : BaseTest
    {
        [Fact]
        public void UC1_RegisterNewUser_WithValidData_ShouldLoginCreatedUser()
        {
            // Arrange

            var user = new UserRegistrationData("John", "Smith", $"john.smith.{Guid.NewGuid():N}@test.com", "10 Main Street", "London", "Greater London", "SW1A1AA", "United Kingdom", $"john{Guid.NewGuid():N}"[..15], "Test12345");

            var RegistrationPage = new RegistrationPage(Driver);

            // Act
            var accountPage = RegistrationPage.Open()
                                              .FillRegistrationForm(user)
                                              .SubmitSuccessfulRegistration()
                                              .Continue();

            // Assert

            accountPage.GetWelcomeMessage()
                       .Should()
                       .Contain($"Welcome back {user.FirstName}");

            accountPage.GetUserName()
                       .Should()
                       .Contain(user.FirstName);
        }
        [Fact]
        public void UC2_RegisterNewUser_InvalidData_ShouldGetErrorLabel()
        {
            //Arrange

            var registrationPage = new RegistrationPage(Driver);

            //Act
            registrationPage.Open().SubmitWrongRegistration();

        }
    }
}

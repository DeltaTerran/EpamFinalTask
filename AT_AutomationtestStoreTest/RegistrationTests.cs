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
            var user = new UserRegistrationData(
                "John",
                "Smith",
                $"john.smith.{Guid.NewGuid():N}@test.com",
                "10 Main Street",
                "London",
                "Greater London",
                "SW1A1AA",
                "United Kingdom",
                $"john{Guid.NewGuid():N}"[..15],
                "Test12345");

            var loginPage = new LoginPage(Driver);

            // Act
            var accountPage = loginPage.Open()
                                       .RegisterButtonClick()
                                       .FillRegistrationForm(user)
                                       .Register()
                                       .Continue();

            // Assert
            accountPage.GetWelcomeMessage()
                       .Should()
                       .Contain($"Welcome back {user.FirstName}");

            accountPage.GetUserName()
                       .Should()
                       .Contain(user.FirstName);
        }

        [Theory]
        [InlineData("")]
        [InlineData("a")]
        [InlineData("abcd")]
        [InlineData("login_name_that_is_longer_than_sixty_four_characters_to_test_upperlimit_of_RegistrationPage")]
        public void UC2_RegisterNewUser_InvalidData_ShouldGetErrorLabel(string login)
        {
            // Arrange
            var registrationPage = new RegistrationPage(Driver);

            // Act
            var errorMessage = registrationPage
                .Open()
                .InputLogin(login)
                .Submit()
                .GetLoginErrorLabelText();

            // Assert
            errorMessage.Should()
                .Contain("Login name must be alphanumeric only and between 5 and 64 characters!");
        }
    }
}

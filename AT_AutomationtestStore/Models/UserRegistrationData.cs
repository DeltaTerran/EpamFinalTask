namespace AT_AutomationtestStore.Models
{
    public record UserRegistrationData(
        string FirstName,
        string LastName,
        string Email,
        string Address,
        string City,
        string Region,
        string ZipCode,
        string Country,
        string Login,
        string Password);
}

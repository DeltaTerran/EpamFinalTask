namespace AT_AutomationtestStore.Models
{
    /// <summary>
    /// Represents user data required to complete the account registration form.
    /// </summary>
    public sealed class UserRegistrationData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRegistrationData"/> class.
        /// </summary>
        /// <param name="firstName">The user's first name.</param>
        /// <param name="lastName">The user's last name.</param>
        /// <param name="email">The user's email address.</param>
        /// <param name="address">The user's address.</param>
        /// <param name="city">The user's city.</param>
        /// <param name="region">The user's region or state.</param>
        /// <param name="zipCode">The user's ZIP or postal code.</param>
        /// <param name="country">The user's country.</param>
        /// <param name="login">The login name used to access the account.</param>
        /// <param name="password">The password used to access the account.</param>
        public UserRegistrationData(
            string firstName,
            string lastName,
            string email,
            string address,
            string city,
            string region,
            string zipCode,
            string country,
            string login,
            string password)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Address = address;
            this.City = city;
            this.Region = region;
            this.ZipCode = zipCode;
            this.Country = country;
            this.Login = login;
            this.Password = password;
        }

        /// <summary>
        /// Gets the user's first name.
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Gets the user's last name.
        /// </summary>
        public string LastName { get; }

        /// <summary>
        /// Gets the user's email address.
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Gets the user's address.
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Gets the user's city.
        /// </summary>
        public string City { get; }

        /// <summary>
        /// Gets the user's region or state.
        /// </summary>
        public string Region { get; }

        /// <summary>
        /// Gets the user's ZIP or postal code.
        /// </summary>
        public string ZipCode { get; }

        /// <summary>
        /// Gets the user's country.
        /// </summary>
        public string Country { get; }

        /// <summary>
        /// Gets the login name used to access the user's account.
        /// </summary>
        public string Login { get; }

        /// <summary>
        /// Gets the password used to access the user's account.
        /// </summary>
        public string Password { get; }
    }
}

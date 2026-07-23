Task description
Site for testing: https://automationteststore.com
UC-1 Test creation of a new account:
oOpen “Login or register” page.
oClick “Continue” on the section “I am a new customer.”.
oFill in all required fields on registration form and click “Continue”.
oCheck that you are logged in under created account:
- “My Account” page is displayed and contains your username;
- page header contains the item called “Welcome back <your_username>”
UC-2 Test validation messages on Registration form:
oOpen “Login or register” page.
oClick “Continue” on the section “I am a new customer.”.
oLeave all fields blank and click “Continue”.
oCheck that an error message “Login name must be alphanumeric only and between <min> and <max> characters!” is displayed under “Login name” field each time when user enters the value that is out of a valid range.
UC-3 Test Special offers:
oOpen “Special offers” page by clicking “Specials” in the header.
oCheck that all products displayed on the page has a discount.
Provide possibility to execute tests in parallel, add logging to track execution flow and use data-driven testing approach.
Make sure that all tasks are supported by these 3 conditions: UC-1; UC-2; UC-3.
Please, add task description as README.md into your solution!
To perform the task use the various of additional options:
Test Automation tool: Selenium WebDriver;
Browsers: 1) Chrome; 2) Firefox;
Locators: CSS;
Test Runner: xUnit;
Assertions: Fluent Assertion;
[Optional] Patterns: 1) Singleton; 2) Factory method; 3) Abstract Factory;
[Optional] Test automation approach: BDD;
[Optional] Loggers: Serilog.


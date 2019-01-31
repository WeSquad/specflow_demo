Feature: TestLogin
	The login goes with a username and a password.
	The username must contain at least one letter and have at least 8 characters
	The password can't be empty

@mytag
Scenario Outline: login attempt
	Given user has open IE
	And user has entered a "<username>"
	And user has ented a "<password>"
	When the user press on the login button
	Then the result must be "<valid>"

	Examples: logins
	| username    | password | valid     |
	| testAtLeat8 | test     | valid     |
	| 132456789   | test     | not valid |
	| test        | test     | not valid |
	| testAtLeat8 |    | notvalid  |	

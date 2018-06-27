Feature: Login

Scenario: User connected to one department can login
	Given User connected to one department
	When User connected to one department logs in
	Then User successfully logged in
	And User is connected to only one department

Scenario: User connected to few departments can login
	Given User connected to few departments
	When User connected to few departments logs in
	And User choose first department on login page
	Then User successfully logged in
	And User is connected to few departments

Scenario: User can log out
	Given User connected to one department
	When User connected to one department logs in
	And User successfully logged in
	Then User logs out
	And User is not logged in

Scenario: Selecting dashboard on login for a User connected to multiple departments
	Given User connected to few departments
	And User connected to few departments logs in
	When User choose a random department to display
	Then User Dashboard page opened for selected department

Scenario: Login with invalid password
	Given User with invalid password
	When User connected to one department logs in
	Then User is not logged in
	And User see sign in error message

Scenario: Login with invalid username and password
	Given User with invalid username and password
	When User connected to one department logs in
	Then User is not logged in
	And User see sign in error message

Scenario: Login with API
	Given User connected to one department
	When User connected to one department logs in via API call
	And Test test test
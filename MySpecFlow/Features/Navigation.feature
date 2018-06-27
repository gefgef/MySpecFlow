Feature: Navigation

Scenario: User connected to multiple departments can switch between them
	Given User connected to few departments
	And User connected to few departments logs in
	And User choose first department on login page
	When User choose department department2 to display
	Then Department department2 is displayed
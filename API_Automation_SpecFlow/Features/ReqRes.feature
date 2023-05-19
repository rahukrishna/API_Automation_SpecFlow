Feature: Reqres API validations

@testScenarios

Scenario: Get the List of users
	Given Want to know the users list
	When I retrive the data of users list
	Then Users list should contain some value
Scenario: Get the single user detail
	Given Iwant to get single user details
	When I retrivee data for a single user
	Then I should get the details of singke user
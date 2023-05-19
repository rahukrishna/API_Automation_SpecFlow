Feature: Reqres API validations

@testScenarios

Scenario: Get the List of users
	Given Want to know the users list
	When I retrive the data of users list
	Then Users list should contain some value

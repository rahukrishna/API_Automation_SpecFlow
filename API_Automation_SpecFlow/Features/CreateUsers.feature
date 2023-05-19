Feature: Create user request API validations

@CreatetestScenarios

Scenario Outline: Create a new user
	Given Want to create the user request
	When passing <name> and <job> in the body
	And retrying the data
	Then I should get the response of created request with name <name> and job <job>
	Examples: 
	| name   | job      |
	| RahulK | Engineer |

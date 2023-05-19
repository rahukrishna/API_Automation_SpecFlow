Feature: Update users APi Validations

@updateTestScenarios

Scenario Outline: Update the user
	Given Want to update the user details
	When Passing the name <name> and new Job <newJob>
	And retrying the update data
	Then I should get the response of updated response with name <name> and new job <newJob>
	Examples: 
	| name   | newJob    |
	| RahulK | Architect |
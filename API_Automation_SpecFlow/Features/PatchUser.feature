Feature: Patch users APi 

@PatchUsersScenario

Scenario Outline: Patch the user
	Given Want to patch user details
	When the name <name> and <new job> is provided
	And trying to get the data
	Then the patched response should contain the name <name> and new job <new job>
	Examples: 
	| name   | new job    |
	| RahulK | dev |

@InitializeDriver
@StopDriver
Feature: UbsEbankingSwitzerland

@Smoke
Scenario: Check That It Is Not Possible To Continue Login With Incorrect Contract Number
	Given I have navigated to the UBS E-Banking Switzerland
	When I have entered wrong contract number
	And I have clicked Continue
	Then I have seen the message that contract number is incorrect
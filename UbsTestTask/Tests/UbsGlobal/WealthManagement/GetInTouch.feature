@InitializeDriver
@StopDriver
Feature: GetInTouch

@Smoke
Scenario: Submit Get In Touch Request
	Given I have navigated to the Wealth Management Your Life Goals
	And I have clicked Get in touch button
	When I have filled Your request
	And I have filled Your details
	Then I have confirmed and submitted request
	And I have seen the confirmation
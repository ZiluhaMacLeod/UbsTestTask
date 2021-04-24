@InitializeDriver
@StopDriver
Feature: LanguageSwitch

## This case has bugs: Wealth Management, Asset Management and Investment Bank main menu tabs are not translated to German
@Smoke
@OpenUbsGlobalEn
Scenario: Switch Language To Deutsch
	Given I have checked that current language is en
	When I switched to the de
	Then I check that header elements are written in de now
	And tab elements are written in de now

@Smoke
@OpenUbsGlobalDe
Scenario: Switch Language To English
	Given I have checked that current language is de
	When I switched to the en
	Then I check that header elements are written in en now
	And tab elements are written in en now
@AccountingProcessorTests
Feature: AccountingProcessorTests
	In order to process currencies transaction
	As a acountant
	I want to be told perform currency conversion

Scenario Outline: Get currency baserate
	Given I have rates repo 
	And I have transactions processor
	When I request rate for <currency>
	Then the returned rate should be <rate>

	Examples: 
        | currency | rate | 
        | "usd"    | 1.0  | 
        | "gbp"    | 0.77 | 

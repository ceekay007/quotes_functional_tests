Feature: Draft invoice creation
	As a Xero User,
	In order to manage my business successfully,
	I want to create a draft invoice from an existing accepted Quote


@invoice
Scenario: User successfully creates a draft invoice from an accepted quote
	Given a user is logged in
	And an accepted quote exists
	When user creates an invoice from an accepted quote
	Then draft invoice is created
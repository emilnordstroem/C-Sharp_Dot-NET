Feature: Studerende

A short summary of the feature

Scenario: HentStuderende
	Given Studerende med navn Emil eksistere
	When Klient klikker på Se studerende
	Then Studerende med navn Emil fremvises

Feature: VerificarLosCamposValidos

A short summary of the feature

@tag1
Scenario: [Verificamos que los campos hayan sido insertados]
	Given El cliente ha metido los datos validos en formulario
	When esta por dar click al boton guardar
	Then Verificamos todos los campos validos antes de guardar

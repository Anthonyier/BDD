Feature: ComprobarFormatoEmail

A short summary of the feature

@tag1
Scenario: [Verificar que el email este con el formato correcto]
	Given que el usuario en el WebForm coloca un email 
	When le de click en el boton Guardar 
	Then verificamos que el formato email sea el correcto

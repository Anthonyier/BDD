Feature: ValidacionNumericaEnCantidad

A short summary of the feature

@tag1
Scenario: [Validamos que la cantidad de producto sea integer]
	Given Cuando el usuario escribe la cantidad de prodcuto
	When le da click en el boton agregar
	Then validamos que la cantidad sea Numerica

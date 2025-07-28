Feature: CalculoAutomaticoTotal

A short summary of the feature

@tag1
Scenario: [Calculamos el total del producto]
	Given El Cliente ha logrado insertar los datos del producto para su calculo en la grilla
	When le da al boton de agregar de la grilla
	Then Calculamos el total

Feature: VerificarSiSeHaSelecionadoClienteParalaFactura

A short summary of the feature

@tag1
Scenario: [El usuario no ha escogido un Cliente]
	Given el usuario en el Webform no ha escogido un cliente
	When Cuando le dio click al boton guardar
	Then verificamos y avisamos si el cliente a sido seleccionado

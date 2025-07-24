Feature: verificarDatosObligatorios

A short summary of the feature

@tag1
Scenario: [verificar datos obligatorios]
	Given el usuario llena los datos pedidos para la creacion del cliente
	When se presiona el boton guardar
	Then validamos que los datos requeridos tenga los valores requeridos

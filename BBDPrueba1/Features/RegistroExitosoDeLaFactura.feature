Feature: RegistroExitosoDeLaFactura

A short summary of the feature

@tag1
Scenario: [Registro Exitoso De La Factura]
	Given El Usuario ha logrado meter todos los datos necesarios para la factura de venta
	When  da click en el boton guardar
	Then  Registramos exitosamente la factura

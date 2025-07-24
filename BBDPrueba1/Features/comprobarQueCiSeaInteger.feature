Feature: comprobarQueCiSeaInteger

A short summary of the feature

@tag1
Scenario: [Comprobamos que el Ci o NIT sean Integer]
	Given Cuando escribimos el dato en el txtCI en el Web Form
	When le damos click al boton guardar
	Then validamos que el dato sea un integer

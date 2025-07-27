using CapaLogicaNegocioBDD;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using System;

namespace BBDPrueba1.StepDefinitions
{
    [Binding]

    public class ComprobarLosDatosDelProductoStepDefinitions
    {
        IWebDriver driver;
        NegocioDetalleFacturaVenta objDetalleFacturaVenta=new NegocioDetalleFacturaVenta();

        [Given("El Usuario a introducido todos los datos del producto")]
        public void GivenElUsuarioAIntroducidoTodosLosDatosDelProducto()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://localhost:44395/WebFormFactura");
            driver.FindElement(By.Name("textCantidad")).SendKeys("4");
            driver.FindElement(By.Name("txtPrecio")).SendKeys("30");
        }

        [When("le da click al boton agregar")]
        public void WhenLeDaClickAlBotonAgregar()
        {
            driver.FindElement(By.Name("btnAgregar")).Click();
        }

        [Then("verificamon que los datos hallan sido metidos correctamente")]
        public void ThenVerificamonQueLosDatosHallanSidoMetidosCorrectamente()
        {
            IWebElement elementoRequeridoCantidad = driver.FindElement(By.Id("textCantidad"));
            int cantidadDelProducto = string.IsNullOrWhiteSpace(elementoRequeridoCantidad.GetAttribute("value")) ? 0 : int.Parse(elementoRequeridoCantidad.GetAttribute("value"));
            IWebElement elementoRequeridoPrecio = driver.FindElement(By.Id("txtPrecio"));
            int precioDelProducto = string.IsNullOrWhiteSpace(elementoRequeridoPrecio.GetAttribute("value")) ? 0 : int.Parse(elementoRequeridoPrecio.GetAttribute("value"));
            IWebElement elementoDropdownListProducto = driver.FindElement(By.Id("ddlProducto"));
            SelectElement dropProducto = new SelectElement(elementoDropdownListProducto);
            string valorEscogido = dropProducto.SelectedOption.GetAttribute("value");
            int codProdcuto= string.IsNullOrWhiteSpace(valorEscogido) ? 0 : int.Parse(valorEscogido);
            int verificacion = objDetalleFacturaVenta.comprobraDatosDeProducto(codProdcuto, cantidadDelProducto,precioDelProducto);
            Assert.AreEqual(1, verificacion);
        }
    }
}

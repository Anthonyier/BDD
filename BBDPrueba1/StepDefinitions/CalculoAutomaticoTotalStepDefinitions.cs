using CapaLogicaNegocioBDD;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using System;

namespace BBDPrueba1.StepDefinitions
{
    [Binding]
    public class CalculoAutomaticoTotalStepDefinitions
    {
        IWebDriver driver;
        NegocioDetalleFacturaVenta objDetalleFacturaVenta=new NegocioDetalleFacturaVenta();
        [Given("El Cliente ha logrado insertar los datos del producto para su calculo en la grilla")]
        public void GivenElClienteHaLogradoInsertarLosDatosDelProductoParaSuCalculoEnLaGrilla()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://localhost:44395/WebFormFactura");
            driver.FindElement(By.Name("textCantidad")).SendKeys("2");
            driver.FindElement(By.Name("txtPrecio")).SendKeys("100");
            IWebElement dropdown = driver.FindElement(By.Name("ddlProducto"));
            SelectElement select = new SelectElement(dropdown);
            select.SelectByText("Taladro bosch");
        
        }

        [When("le da al boton de agregar de la grilla")]
        public void WhenLeDaAlBotonDeAgregarDeLaGrilla()
        {
            driver.FindElement(By.Name("btnAgregar")).Click();
        }

        [Then("Calculamos el total")]
        public void ThenCalculamosElTotal()
        {
            IWebElement elementoRequeridoCantidad = driver.FindElement(By.Id("textCantidad"));
            objDetalleFacturaVenta.cantidad  = string.IsNullOrWhiteSpace(elementoRequeridoCantidad.GetAttribute("value")) ? 0 : int.Parse(elementoRequeridoCantidad.GetAttribute("value"));
            IWebElement elementoRequeridoPrecio = driver.FindElement(By.Id("txtPrecio"));
            objDetalleFacturaVenta.precio = string.IsNullOrWhiteSpace(elementoRequeridoPrecio.GetAttribute("value")) ? 0 : int.Parse(elementoRequeridoPrecio.GetAttribute("value"));
            objDetalleFacturaVenta.total = objDetalleFacturaVenta.calcularTotal(objDetalleFacturaVenta.precio, objDetalleFacturaVenta.cantidad);
            Assert.AreEqual(200, objDetalleFacturaVenta.total);
        }
    }
}

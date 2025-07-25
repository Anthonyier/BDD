using CapaLogicaNegocioBDD;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using System;

namespace BBDPrueba1.StepDefinitions
{
    [Binding]
    public class VerificarSiSeHaSelecionadoClienteParalaFacturaStepDefinitions
    {
        IWebDriver driver;
        NegocioFacturaVenta objFacturaVenta=new NegocioFacturaVenta();
        
        [Given("el usuario en el Webform no ha escogido un cliente")]
        public void GivenElUsuarioEnElWebformNoHaEscogidoUnCliente()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://localhost:44395/WebFormFactura");
        }

        [When("Cuando le dio click al boton guardar")]
        public void WhenCuandoLeDioClickAlBotonGuardar()
        {
            driver.FindElement(By.Name("BotonGuardarFacturaVenta")).Click();
        }

        [Then("verificamos y avisamos si el cliente a sido seleccionado")]
        public void ThenVerificamosYAvisamosSiElClienteASidoSeleccionado()
        {
            IWebElement elementoRequeridoNombre = driver.FindElement(By.Id("textCliente"));
            string nombreDeCliente = elementoRequeridoNombre.Text;
            int verificacion = objFacturaVenta.verificarClienteNoVacio(nombreDeCliente);
            Assert.AreEqual(1, verificacion);
        }
    }
}

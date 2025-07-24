using CapaLogicaNegocioBDD;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using System;

namespace BBDPrueba1.StepDefinitions
{
    [Binding]
    public class VerificarDatosObligatoriosStepDefinitions
    {
        IWebDriver driver;

        NegocioCliente objCliente = new NegocioCliente();

        [Given("el usuario llena los datos pedidos para la creacion del cliente")]
        public void GivenElUsuarioLlenaLosDatosPedidosParaLaCreacionDelCliente()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://localhost:44395/WebFormCliente");
           
        }

        [When("se presiona el boton guardar")]
        public void WhenSePresionaElBotonGuardar()
        {
            driver.FindElement(By.Name("BtnGuardar")).Click();
        }

        [Then("validamos que los datos requeridos tenga los valores requeridos")]
        public void ThenValidamosQueLosDatosRequeridosTengaLosValoresRequeridos()
        {
            //IWebElement elementoRequerido = driver.FindElement(By.Id("RequiredFieldValidator1"));
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //wait.Until(d => d.FindElement(By.Id("RequiredFieldValidator1")).Displayed);
            //string comprobarObligatorio = elementoRequerido.Text;
            //Console.WriteLine("Mensaje mostrado: " + elementoRequerido.Text);
            //Assert.AreEqual("Porfavor Inserte el nombre",comprobarObligatorio);

            IWebElement elementoRequeridoNombre= driver.FindElement(By.Id("txtNombres"));
            string nombre= elementoRequeridoNombre.Text;
            IWebElement elementoRequeridoCi = driver.FindElement(By.Id("txtCI"));
            int ci_Nit = string.IsNullOrWhiteSpace(elementoRequeridoCi.Text) ? 0 : int.Parse(elementoRequeridoCi.Text);
            int verificacion =objCliente.verificarObligatorios(nombre, ci_Nit);
            Assert.AreEqual(1, verificacion);

        }
    }
}

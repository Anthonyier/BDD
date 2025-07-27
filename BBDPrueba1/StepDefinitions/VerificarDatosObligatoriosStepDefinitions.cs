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
            driver.FindElement(By.Name("txtCodigo")).SendKeys("4755Sc");
            driver.FindElement(By.Name("txtCI")).SendKeys("7482322");
            driver.FindElement(By.Name("txtNombres")).SendKeys("Alberto Obregon");
            driver.FindElement(By.Name("txtEmail")).SendKeys("alberOreg@gmail.com");

            IWebElement dropdown = driver.FindElement(By.Name("ddlTipoDoc"));
            SelectElement select = new SelectElement(dropdown);
            select.SelectByText("Pasaporte");

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

            IWebElement elementoRequeridoCodigo = driver.FindElement(By.Id("txtCodigo"));
            string codigo= elementoRequeridoCodigo.GetAttribute("value");
            IWebElement elementoRequeridoNombre= driver.FindElement(By.Id("txtNombres"));
            string nombre= elementoRequeridoNombre.GetAttribute("value");
            IWebElement elementoRequeridoCi = driver.FindElement(By.Id("txtCI"));
            int ci_Nit = string.IsNullOrWhiteSpace(elementoRequeridoCi.GetAttribute("value")) ? 0 : int.Parse(elementoRequeridoCi.GetAttribute("value"));
            IWebElement elementoRequeridoCorreo = driver.FindElement(By.Id("txtEmail"));
            string correo = elementoRequeridoCorreo.GetAttribute("value"); 
            IWebElement elementoDropdownListTipoDoc = driver.FindElement(By.Id("ddlTipoDoc"));
            SelectElement dropTipoDoc = new SelectElement(elementoDropdownListTipoDoc);
            string valorEscogidoTipoDoc = dropTipoDoc.SelectedOption.GetAttribute("value");

            Console.WriteLine(valorEscogidoTipoDoc);
            int verificacion =objCliente.verificarObligatorios(nombre, ci_Nit,codigo,correo,valorEscogidoTipoDoc);
            Assert.AreEqual(0, verificacion);

        }
    }
}

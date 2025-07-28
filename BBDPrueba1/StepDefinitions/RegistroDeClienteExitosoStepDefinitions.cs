using CapaLogicaNegocioBDD;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using System;

namespace BBDPrueba1.StepDefinitions
{
    [Binding]
    public class RegistroDeClienteExitosoStepDefinitions
    {
        IWebDriver driver;
        [Given("El usuario ha logrado meter los datos correctamente")]
        public void GivenElUsuarioHaLogradoMeterLosDatosCorrectamente()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://localhost:44395/WebFormCliente");
            driver.FindElement(By.Name("txtCodigo")).SendKeys("4755Sc");
            driver.FindElement(By.Name("txtCI")).SendKeys("7482322");
            driver.FindElement(By.Name("txtNombres")).SendKeys("Alberto Obregon");

            IWebElement dropdown = driver.FindElement(By.Name("ddlTipoDoc"));
            SelectElement select = new SelectElement(dropdown);
            select.SelectByText("Pasaporte");

            driver.FindElement(By.Name("txtEmail")).SendKeys("alberOreg@gmail.com");
            driver.FindElement(By.Name("txtTelefono")).SendKeys("78595551");
        }

        [When("le da click al boton guardar")]
        public void WhenLeDaClickAlBotonGuardar()
        {
            driver.FindElement(By.Name("BtnGuardar")).Click();
        }

        [Then("el cliente se registra corectamente")]
        public void ThenElClienteSeRegistraCorectamente()
        {
            //NegocioCliente objCliente = new NegocioCliente();
            //IWebElement elementoRequeridoCodigo = driver.FindElement(By.Id("txtCodigo"));
            //objCliente.codigo = elementoRequeridoCodigo.GetAttribute("value");
            //IWebElement elementoRequeridoNombre = driver.FindElement(By.Id("txtNombres"));
            //objCliente.nombre = elementoRequeridoNombre.GetAttribute("value");
            //IWebElement elementoRequeridoCi = driver.FindElement(By.Id("txtCI"));
            //objCliente.ci_Nit = string.IsNullOrWhiteSpace(elementoRequeridoCi.GetAttribute("value")) ? 0 : int.Parse(elementoRequeridoCi.GetAttribute("value"));
            //IWebElement elementoRequeridoCorreo = driver.FindElement(By.Id("txtEmail"));
            //objCliente.email = elementoRequeridoCorreo.GetAttribute("value"); ;
            //IWebElement elementoDropdownListTipoDoc = driver.FindElement(By.Id("ddlTipoDoc"));
            //SelectElement dropTipoDoc = new SelectElement(elementoDropdownListTipoDoc);
            //objCliente.tipoDoc = dropTipoDoc.SelectedOption.GetAttribute("value");
            //IWebElement elementoRequeridoNroTelefono = driver.FindElement(By.Id("txtTelefono"));
            //objCliente.nroTelefono= string.IsNullOrWhiteSpace(elementoRequeridoNroTelefono.GetAttribute("value")) ? 0 : int.Parse(elementoRequeridoNroTelefono.GetAttribute("value"));

            //int resultado = objCliente.guardarCliente();
            //Assert.AreEqual(1, resultado);

            IWebElement label = driver.FindElement(By.Id("LabelGuardar"));
            Assert.IsTrue(label.Displayed, "No se Pudo Insertar el Cliente.");
        }
    }
}

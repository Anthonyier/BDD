using CapaLogicaNegocioBDD;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using System;

namespace BBDPrueba1.StepDefinitions
{
    [Binding]
    public class VerificarLosCamposValidosStepDefinitions
    {
        IWebDriver driver;
        NegocioCliente objCliente = new NegocioCliente();
        [Given("El cliente ha metido los datos validos en formulario")]
        public void GivenElClienteHaMetidoLosDatosValidosEnFormulario()
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
        }

        [When("esta por dar click al boton guardar")]
        public void WhenEstaPorDarClickAlBotonGuardar()
        {
            driver.FindElement(By.Name("BtnGuardar")).Click();
        }

        [Then("Verificamos todos los campos validos antes de guardar")]
        public void ThenVerificamosTodosLosCamposValidosAntesDeGuardar()
        {
            IWebElement elementoRequeridoInteger = driver.FindElement(By.Id("CompareValidator1"));
            bool comprobarInteger = elementoRequeridoInteger.Displayed;
            Assert.IsFalse(comprobarInteger, "El Ci/Nit deberia Ser integer ");

            IWebElement elementoRequeridoEmail = driver.FindElement(By.Id("RegularExpressionValidator1"));
            bool emailVisible = elementoRequeridoEmail.Displayed;
            Assert.IsFalse(emailVisible, "El Email  esta mal escrito");

            IWebElement elementoRequeridoCodigo = driver.FindElement(By.Id("txtCodigo"));
            string codigo = elementoRequeridoCodigo.GetAttribute("value");
            IWebElement elementoRequeridoNombre = driver.FindElement(By.Id("txtNombres"));
            string nombre = elementoRequeridoNombre.GetAttribute("value");
            IWebElement elementoRequeridoCi = driver.FindElement(By.Id("txtCI"));
            int ci_Nit = string.IsNullOrWhiteSpace(elementoRequeridoCi.GetAttribute("value")) ? 0 : int.Parse(elementoRequeridoCi.GetAttribute("value"));
            IWebElement elementoRequeridoCorreo = driver.FindElement(By.Id("txtEmail"));
            string correo = elementoRequeridoCorreo.GetAttribute("value"); ;
            IWebElement elementoDropdownListTipoDoc = driver.FindElement(By.Id("ddlTipoDoc"));
            SelectElement dropTipoDoc = new SelectElement(elementoDropdownListTipoDoc);
            string valorEscogidoTipoDoc = dropTipoDoc.SelectedOption.GetAttribute("value");

            Console.WriteLine(codigo + " " + nombre + "" + ci_Nit + "" + correo );

            int verificacion = objCliente.verificarObligatorios(nombre, ci_Nit, codigo, correo,valorEscogidoTipoDoc);
            Assert.AreEqual(0, verificacion);
        }
    }
}

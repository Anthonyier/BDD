using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using System;

namespace BBDPrueba1.StepDefinitions
{
    [Binding]
    public class ComprobarFormatoEmailStepDefinitions
    {
        IWebDriver driver;

        [Given("que el usuario en el WebForm coloca un email")]
        public void GivenQueElUsuarioEnElWebFormColocaUnEmail()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://localhost:44395/WebFormCliente");
            driver.FindElement(By.Name("txtEmail")).SendKeys("pedritogmail.com");
            driver.FindElement(By.Name("txtCodigo")).SendKeys("4755Sc");
            driver.FindElement(By.Name("txtCI")).SendKeys("7482322");
            driver.FindElement(By.Name("txtNombres")).SendKeys("Alberto Obregon");

            IWebElement dropdown = driver.FindElement(By.Name("ddlTipoDoc"));
            SelectElement select = new SelectElement(dropdown);
            select.SelectByText("Pasaporte");
        }

        [When("le de click en el boton Guardar")]
        public void WhenLeDeClickEnElBotonGuardar()
        {
            driver.FindElement(By.Name("BtnGuardar")).Click();
        }

        [Then("verificamos que el formato email sea el correcto")]
        public void ThenVerificamosQueElFormatoEmailSeaElCorrecto()
        {
            IWebElement elementoRequerido = driver.FindElement(By.Id("RegularExpressionValidator1"));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(By.Id("RegularExpressionValidator1")).Displayed);
            string comprobarObligatorio = elementoRequerido.Text;
            Console.WriteLine("Mensaje mostrado: " + elementoRequerido.Text);
            Assert.AreEqual("Invalid Email", comprobarObligatorio);
        }
    }
}

using System;
using Reqnroll;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace BBDPrueba1.StepDefinitions
{
    [Binding]
    public class ComprobarQueCiSeaIntegerStepDefinitions
    {
        IWebDriver driver;

        [Given("Cuando escribimos el dato en el txtCI en el Web Form")]
        public void GivenCuandoEscribimosElDatoEnElTxtCIEnElWebForm()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://localhost:44395/WebFormCliente");
            driver.FindElement(By.Name("txtCI")).SendKeys("8741224gfgh1");
        }

        [When("le damos click al boton guardar")]
        public void WhenLeDamosClickAlBotonGuardar()
        {
            driver.FindElement(By.Name("BtnGuardar")).Click();
        }

        [Then("validamos que el dato sea un integer")]
        public void ThenValidamosQueElDatoSeaUnInteger()
        {
            IWebElement elementoRequerido = driver.FindElement(By.Id("CompareValidator1"));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(By.Id("CompareValidator1")).Displayed);
            string comprobarInteger = elementoRequerido.Text;
            Console.WriteLine("Mensaje mostrado: " + elementoRequerido.Text);
            Assert.AreEqual("Inserte bien el CI con numeros", comprobarInteger);
        }
    }
}

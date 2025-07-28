using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using System;

namespace BBDPrueba1.StepDefinitions
{
    [Binding]
    public class ValidacionNumericaEnCantidadStepDefinitions
    {
        IWebDriver driver;
        [Given("Cuando el usuario escribe la cantidad de prodcuto")]
        public void GivenCuandoElUsuarioEscribeLaCantidadDeProdcuto()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://localhost:44395/WebFormFactura");
            driver.FindElement(By.Name("textCantidad")).SendKeys("abc");
            driver.FindElement(By.Name("txtPrecio")).SendKeys("100");
            IWebElement dropdown = driver.FindElement(By.Name("ddlProducto"));
            SelectElement select = new SelectElement(dropdown);
            select.SelectByText("Taladro bosch");
        
        }

        [When("le da click en el boton agregar")]
        public void WhenLeDaClickEnElBotonAgregar()
        {
            driver.FindElement(By.Name("btnAgregar")).Click();
        }

        [Then("validamos que la cantidad sea Numerica")]
        public void ThenValidamosQueLaCantidadSeaNumerica()
        {
            IWebElement elementoRequerido = driver.FindElement(By.Id("CompareValidator1"));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(By.Id("CompareValidator1")).Displayed);
            string comprobarInteger = elementoRequerido.Text;
            Console.WriteLine("Mensaje mostrado: " + elementoRequerido.Text);
            Assert.AreEqual("Cantidad debe ser un numero", comprobarInteger);
        }
    }
}

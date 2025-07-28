using CapaLogicaNegocioBDD;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using System;

namespace BBDPrueba1.StepDefinitions
{
    [Binding]
    public class RegistroExitosoDeLaFacturaStepDefinitions
    {
        IWebDriver driver;
        
        [Given("El Usuario ha logrado meter todos los datos necesarios para la factura de venta")]
        public void GivenElUsuarioHaLogradoMeterTodosLosDatosNecesariosParaLaFacturaDeVenta()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://localhost:44395/WebFormFactura");

            IWebElement dropdown = driver.FindElement(By.Name("ddlClienteCodigo"));
            SelectElement select = new SelectElement(dropdown);
            select.SelectByText("5775ded");

            IWebElement dropdownTipoContato = driver.FindElement(By.Name("ddlTipoPago"));
            SelectElement selectTipoContrato = new SelectElement(dropdownTipoContato);
            selectTipoContrato.SelectByText("Al Contado");


            IWebElement dropdownProducto = driver.FindElement(By.Name("ddlProducto"));
            SelectElement selectProducto = new SelectElement(dropdownProducto);
            selectProducto.SelectByText("Taladro bosch");

            driver.FindElement(By.Name("textCantidad")).SendKeys("2");
            driver.FindElement(By.Name("txtPrecio")).SendKeys("100");
            driver.FindElement(By.Name("btnAgregar")).Click();


        }

        [When("da click en el boton guardar")]
        public void WhenDaClickEnElBotonGuardar()
        {
            driver.FindElement(By.Name("BotonGuardarFacturaVenta")).Click();
        }

        [Then("Registramos exitosamente la factura")]
        public void ThenRegistramosExitosamenteLaFactura()
        {
            //    NegocioFacturaVenta objFacturaVenta = new NegocioFacturaVenta();
            //    NegocioDetalleFacturaVenta objDetalleFacturaVenta = new NegocioDetalleFacturaVenta();

            //    objFacturaVenta.id = objFacturaVenta.encontraMaximoFacturaVentaId();

            //    IWebElement elementoRequeridoCodigo = driver.FindElement(By.Id("txtCodigo"));
            //    objFacturaVenta.codigo = elementoRequeridoCodigo.GetAttribute("value");
            //    IWebElement elementoRequeridoNombre = driver.FindElement(By.Id("txtNombres"));
            //    objCliente.nombre = elementoRequeridoNombre.GetAttribute("value");
            //    IWebElement elementoRequeridoCi = driver.FindElement(By.Id("txtCI"));
            //    objCliente.ci_Nit = string.IsNullOrWhiteSpace(elementoRequeridoCi.GetAttribute("value")) ? 0 : int.Parse(elementoRequeridoCi.GetAttribute("value"));
            //    IWebElement elementoRequeridoCorreo = driver.FindElement(By.Id("txtEmail"));
            //    objCliente.email = elementoRequeridoCorreo.GetAttribute("value"); ;
            //    IWebElement elementoDropdownListTipoDoc = driver.FindElement(By.Id("ddlTipoDoc"));
            //    SelectElement dropTipoDoc = new SelectElement(elementoDropdownListTipoDoc);
            //    objCliente.tipoDoc = dropTipoDoc.SelectedOption.GetAttribute("value");
            //    IWebElement elementoRequeridoNroTelefono = driver.FindElement(By.Id("txtTelefono"));
            //    objCliente.nroTelefono = string.IsNullOrWhiteSpace(elementoRequeridoNroTelefono.GetAttribute("value")) ? 0 : int.Parse(elementoRequeridoNroTelefono.GetAttribute("value"));

            IWebElement label = driver.FindElement(By.Id("LabelFacturaGuardar"));
            Assert.IsTrue(label.Displayed, "No se Pudo Insertar la Factura.");
        }
    }
}

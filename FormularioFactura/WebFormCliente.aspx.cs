using CapaLogicaNegocioBDD;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormularioFactura
{
    public partial class WebFormCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarTipoDoc();
            }
        }

        public void cargarTipoDoc()
        {
            ddlTipoDoc.Items.Clear();
            ddlTipoDoc.Items.Add(new ListItem("Seleccione el Tipo de documento", ""));
            ddlTipoDoc.Items.Add(new ListItem("Carnet", "Carnet"));
            ddlTipoDoc.Items.Add(new ListItem("Pasaporte", "Pasaporte"));
            ddlTipoDoc.Items.Add(new ListItem("Libreta", "Libreta"));
            ddlTipoDoc.Items.Add(new ListItem("Carnet Extranjero", "Carnet Extranjero"));
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!comprobarSiCiEsInteger())
            {
                return;
            }
            if (!comprobarFormatoEmail())
            {
                return;
            }
            NegocioCliente cliente = obtenerCliente();
            if (cliente != null)
            {
                if (cliente.guardarCliente() == 1)
                {
                    Label1.Visible = true;
                }
            }
        }

        public bool comprobarSiCiEsInteger()
        {
            bool comprobarInteger = CompareValidator1.IsValid;
            return comprobarInteger;

        }
        public bool comprobarFormatoEmail()
        {
            bool comprobarEmail = RegularExpressionValidator1.IsValid ;
            return comprobarEmail;
        }

        public NegocioCliente obtenerCliente()
        {
            NegocioCliente objCliente= new NegocioCliente();
            objCliente.codigo = txtCodigo.Text;
            objCliente.ci_Nit = Convert.ToInt32(txtCI.Text);
            objCliente.nombre = txtNombres.Text;
            objCliente.email = txtEmail.Text;
            objCliente.tipoDoc = ddlTipoDoc.SelectedItem.Value;
            objCliente.nroTelefono = Convert.ToInt32(txtTelefono.Text);
            int verificacion = objCliente.verificarObligatorios(objCliente.nombre, objCliente.ci_Nit , objCliente.codigo, objCliente.email, objCliente.tipoDoc);
            if(verificacion == 1)
            {
                return null;
            }
            else
            {
                return objCliente;
            }

        }
    }
}
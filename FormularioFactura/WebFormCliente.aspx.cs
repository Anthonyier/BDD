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
            ddlTipoDoc.Items.Add(new ListItem("Carnet", "Carnet"));
            ddlTipoDoc.Items.Add(new ListItem("Pasaporte", "Pasaporte"));
            ddlTipoDoc.Items.Add(new ListItem("Libreta", "Libreta"));
            ddlTipoDoc.Items.Add(new ListItem("Carnet Extranjero", "Carnet Extranjero"));
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}
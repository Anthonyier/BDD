using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormularioFactura
{
    public partial class WebFormFactura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarProducto();
            }
        }

        public void cargarProducto()
        {
            ddlProducto.Items.Clear();
            ddlProducto.Items.Add(new ListItem("Seleccion Producto", ""));
            ddlProducto.Items.Add(new ListItem("Taladro bosch","1" ));
            ddlProducto.Items.Add(new ListItem("Martillo", "2"));
            ddlProducto.Items.Add(new ListItem("Destornillador", "3"));
            ddlProducto.Items.Add(new ListItem("Alicate", "4"));
        }
    }
}
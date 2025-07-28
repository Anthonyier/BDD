using CapaLogicaNegocioBDD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormularioFactura
{
    public partial class WebFormFactura : System.Web.UI.Page
    {
        DataTable TablaTemporal
        {
            get
            {
                return ViewState["TablaFactura"] as DataTable;
            }
            set
            {
                ViewState["TablaFactura"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarProducto();
                DataTable dt = new DataTable();
                dt.Columns.Add("IdProducto");
                dt.Columns.Add("NombreProducto");
                dt.Columns.Add("Cantidad");
                dt.Columns.Add("Precio");
                dt.Columns.Add("Total");
                TablaTemporal = dt;
                gridViewFactura.DataSource = dt;
                gridViewFactura.DataBind();

                cargarCliente();
                cargarCondicionPago();
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
        public void cargarCondicionPago()
        {
            ddlTipoPago.Items.Clear();
            ddlTipoPago.Items.Add(new ListItem("Seleccion Condicion De Pago", ""));
            ddlTipoPago.Items.Add(new ListItem("Al Contado", "Al Contado"));
            ddlTipoPago.Items.Add(new ListItem("Al Credito", "Al Credito"));
        }
        public void cargarCliente()
        {
            NegocioCliente cliente= new NegocioCliente();
            ddlClienteCodigo.DataSource = cliente.obtenerCliente();
            ddlClienteCodigo.DataTextField = "codigo";
            ddlClienteCodigo.DataValueField = "id";
            ddlClienteCodigo.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            NegocioDetalleFacturaVenta objDetalleFacturaVenta = new NegocioDetalleFacturaVenta();
            int productoId = int.Parse(ddlProducto.SelectedItem.Value);
            string nombreProducto = ddlProducto.SelectedItem.Text;
            int cantidad = int.Parse(textCantidad.Text);
            double precio = double.Parse(txtPrecio.Text);
            if (objDetalleFacturaVenta.comprobraDatosDeProducto(productoId, cantidad, precio) == 0)
            {
                DataTable dt = TablaTemporal;
                double total = objDetalleFacturaVenta.calcularTotal(precio, cantidad);
                dt.Rows.Add(productoId.ToString(), nombreProducto,cantidad.ToString(),precio.ToString(),total.ToString());
                TablaTemporal = dt;
                gridViewFactura.DataSource = dt;
                gridViewFactura.DataBind();
                CalcularTotal();
            }

          
        }

        public void CalcularTotal()
        {
            TextBoxtotal.Text = "0";
            foreach (GridViewRow fila in gridViewFactura.Rows)
            {
                double valorTotal= Convert.ToDouble(fila.Cells[4].Text);
                double valorTexto= Convert.ToDouble(TextBoxtotal.Text);
                TextBoxtotal.Text = Convert.ToString(valorTotal + valorTexto);
            }        
        
        }

        protected void ddlClienteCodigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            NegocioCliente negCliente = new NegocioCliente();
            int Id = Convert.ToInt32(ddlClienteCodigo.Text);
            textCliente.Text = negCliente.buscarNombre(Id);
        }

        protected void BotonGuardarFacturaVenta_Click(object sender, EventArgs e)
        {
            int Result = 0;
            NegocioFacturaVenta objFacturaVenta=new NegocioFacturaVenta();
            objFacturaVenta.id = objFacturaVenta.encontraMaximoFacturaVentaId();
            objFacturaVenta.total = Convert.ToDouble(TextBoxtotal.Text);
            objFacturaVenta.condicionDePago = ddlTipoPago.SelectedItem.Value;
            objFacturaVenta.objCliente.id =Convert.ToInt32( ddlClienteCodigo.SelectedValue);
            if (objFacturaVenta.guardarFacturaVentas() == 1)
            {
                foreach (GridViewRow fila in gridViewFactura.Rows)
                {
                    NegocioDetalleFacturaVenta objDetalleFactura = new NegocioDetalleFacturaVenta();
                    objDetalleFactura.objProducto.codigo= Convert.ToInt32(fila.Cells[0].Text);
                    objDetalleFactura.cantidad = Convert.ToInt32(fila.Cells[2].Text);
                    objDetalleFactura.precio = Convert.ToDouble(fila.Cells[3].Text);
                    objDetalleFactura.total = Convert.ToDouble(fila.Cells[4].Text);
                    objDetalleFactura.objFacturaVenta.id = objFacturaVenta.id;
                    Result=objDetalleFactura.guardarDetalleFacturaVenta();
                }
                if (Result == 1)
                {
                    LabelFacturaGuardar.Visible = true;
                }
            }
        }
    }
}
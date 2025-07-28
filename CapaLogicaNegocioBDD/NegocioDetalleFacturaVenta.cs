using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocioBDD
{
    public class NegocioDetalleFacturaVenta
    {
        public int id {  get; set; }
        public int cantidad { get; set; }
        public double precio { get; set; }
        public double total { get; set; }
        public NegocioFacturaVenta objFacturaVenta { get; set; }
        public NegocioProducto objProducto { get; set; }
        public DatosDetalleFacturaVenta objDetalleFacturaVenta = new DatosDetalleFacturaVenta();
        public NegocioDetalleFacturaVenta()
        {
            objFacturaVenta=new NegocioFacturaVenta();
            objProducto=new NegocioProducto();
        }

        public int comprobraDatosDeProducto(int codigoProdcuto, int cantidad, double precio)
        {
            this.precio = precio;
            this.cantidad = cantidad;
            this.objProducto.codigo = codigoProdcuto;
            if (precio == 0 || cantidad == 0 || this.objProducto.codigo == 0)
            {
                return 1;
            }
            return 0;
        }

        public double calcularTotal(double Precio, int Cantidad)
        {
            double totalFacturaVenta = Precio * Cantidad;
            return totalFacturaVenta;
        }
        public int guardarDetalleFacturaVenta()
        {
            return objDetalleFacturaVenta.guardarDetalleFacturaVentas(this.cantidad, this.precio, this.total, this.objFacturaVenta.id,this.objProducto.codigo);
        }
    }
}

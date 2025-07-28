using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocioBDD
{
    public class NegocioFacturaVenta
    {
        public int id {  get; set; }
        public double total { get; set; }
        public string condicionDePago { get; set; }
         public NegocioCliente objCliente { get;set; }
        public DatosFacturaVentas objFacturaVentas = new DatosFacturaVentas();

        public NegocioFacturaVenta() 
        { 
            objCliente = new NegocioCliente();
        
        }


        public int verificarClienteNoVacio(string nombre)
        {
            this.objCliente.nombre=nombre;
            if (string.IsNullOrEmpty(objCliente.nombre))
            {
                return 1;
            }
            return 0;
        }

        public int guardarFacturaVentas()
        {
            return objFacturaVentas.guardarFacturaVentas(this.id,this.total, this.condicionDePago,this.objCliente.id);
        }

        public int encontraMaximoFacturaVentaId()
        {
            return objFacturaVentas.encontrarIdFacturaVentaMaximo();
        }
    }
}

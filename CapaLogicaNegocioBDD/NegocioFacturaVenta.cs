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
    }
}

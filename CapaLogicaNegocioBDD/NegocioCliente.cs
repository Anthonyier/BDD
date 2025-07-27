using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocioBDD
{

    public class NegocioCliente
    {
        public int id {  get; set; }
        public string codigo {  get; set; } 
        public string nombre { get; set; }
        public int ci_Nit { get; set; }
        public string email { get; set; }
        public string tipoDoc { get; set; }
        public int nroTelefono { get; set; }

        public DatosCliente objCliente = new DatosCliente();
        public int verificarObligatorios(string Nombre,int Ci,string Codigo,string Email,string TipoDoc)
        {
            this.nombre = Nombre;
            this.ci_Nit = Ci;
            this.codigo= Codigo;
            this.email = Email;
            this.tipoDoc = TipoDoc;
            if(string.IsNullOrEmpty(this.nombre) || this.ci_Nit == 0 || string.IsNullOrEmpty(this.codigo) || string.IsNullOrEmpty(this.email) || string.IsNullOrEmpty(this.tipoDoc))
            {
                return 1;
            }
            return 0;
        }

        public int guardarCliente()
        {
            return objCliente.guardarCliente(this.codigo, this.nombre, this.ci_Nit, this.tipoDoc, this.email, this.nroTelefono);
        }

    }
}

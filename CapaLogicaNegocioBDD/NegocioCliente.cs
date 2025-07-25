using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocioBDD
{

    public class NegocioCliente
    {
        public string nombre { get; set; }
        public int ci_Nit { get; set; }
        public string Email { get; set; }
        public string TipoDoc { get; set; }
        public int NroTelefono { get; set; }


        public int verificarObligatorios(string Nombre,int Ci)
        {
            this.nombre = Nombre;
            this.ci_Nit = Ci;
            if(string.IsNullOrEmpty(nombre) || ci_Nit == 0)
            {
                return 1;
            }
            return 0;
        }

    }
}

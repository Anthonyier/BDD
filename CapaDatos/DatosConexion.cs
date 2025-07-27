using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DatosConexion
    {
        private static DatosConexion conexion = null;

        private DatosConexion() { }

        public static DatosConexion getInstace()
        {
            if (conexion == null)
            {
                conexion = new DatosConexion();
            }
            return conexion;
        }
        public SqlConnection conectar()
        {
            SqlConnection Conexion = new SqlConnection("Data Source = SERVIDOR; Initial Catalog = BDD; Integrated Security = True");
            return Conexion;
        }
    }
}

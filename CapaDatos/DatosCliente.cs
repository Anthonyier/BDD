using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DatosCliente
    {
        public DatosCliente() { }

        public int guardarCliente(string Codigo, string Nombre, int Ci,string TipoDoc,string Email,int NroTelefono)
        {

            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            SqlConnection cnx = DatosConexion.getInstace().conectar();
            int fila = 0;
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();

                string sql = "insert into Cliente(codigo,nombre,ci_nit,email,tipoDoc,nroTelefono)" +
                    "values(@codigo,@nombre,@ci_nit,@email,@tipoDoc,@nroTelefono); SELECT @@ROWCOUNT; ";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@codigo", Codigo);
                cmd.Parameters.AddWithValue("@nombre", Nombre);
                cmd.Parameters.AddWithValue("@ci_nit", Ci);
                cmd.Parameters.AddWithValue("@email",Email);
                cmd.Parameters.AddWithValue("@tipoDoc",TipoDoc );
                cmd.Parameters.AddWithValue("@nroTelefono", NroTelefono);
                cmd.Transaction = myTrans;
                fila = cmd.ExecuteNonQuery();
                myTrans.Commit();
                cnx.Close();
            }
            catch (Exception e)
            {
                myTrans.Rollback();
                cnx.Close();
                fila = 0;
                return fila;
            }
            return fila;
        }
    }
}

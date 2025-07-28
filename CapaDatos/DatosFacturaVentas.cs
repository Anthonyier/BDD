using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DatosFacturaVentas
    {

        public int guardarFacturaVentas(int Id, double Total, string CondicionDePago, int IdCliente)
        {

            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            SqlConnection cnx = DatosConexion.getInstace().conectar();
            int fila = 0;
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();

                string sql = "insert into facturaVenta(id,total,condicionDePago,idCliente)" +
                    "values(@id,@total,@condicionDePago,@idCliente); SELECT @@ROWCOUNT; ";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@total", Total);
                cmd.Parameters.AddWithValue("@condicionDePago", CondicionDePago);
                cmd.Parameters.AddWithValue("@idCliente", IdCliente);
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
        public int encontrarIdFacturaVentaMaximo()
        {

            SqlCommand comando = null;
            SqlConnection conex = DatosConexion.getInstace().conectar();
            SqlDataReader lector = null;
            int maximo  = 0;
            try
            {
                comando = new SqlCommand("select max(id) as Maximo from facturaventa" , conex);
                comando.CommandType = CommandType.Text;
                conex.Open();
                lector = comando.ExecuteReader();
                lector.Read();
                
                maximo = Convert.ToInt32(lector["Maximo"].ToString());
                
                
            }
            catch
            {
               maximo = 0;
            }
            finally
            {
                conex.Close();
            }
            return maximo+1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DatosDetalleFacturaVenta
    {
        public int guardarDetalleFacturaVentas(int Cantidad, double Precio, double Total, int IdFacturaVentas,int IdProducto)
        {

            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            SqlConnection cnx = DatosConexion.getInstace().conectar();
            int fila = 0;
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();

                string sql = "insert into detallefacturaVenta(cantidad,precio,total,idFacturaVenta,idProducto)" +
                    "values(@cantidad,@precio,@total,@idFacturaVenta,@idProducto); SELECT @@ROWCOUNT; ";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@cantidad", Cantidad);
                cmd.Parameters.AddWithValue("@precio", Precio);
                cmd.Parameters.AddWithValue("@total", Total);
                cmd.Parameters.AddWithValue("@idFacturaVenta",IdFacturaVentas);
                cmd.Parameters.AddWithValue("@idProducto", IdProducto);
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

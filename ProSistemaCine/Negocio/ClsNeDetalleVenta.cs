using ProSistemaCine.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSistemaCine.Negocio
{
    class ClsNeDetalleVenta
    {
        public DataTable MtdListarDetalleVenta()
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            DataTable dtDetalleVentas = new DataTable("detalleventas");
            try
            {
                SqlCommand sqlCad = new SqlCommand();
                sqlCad.Connection = ClsNeConexion.con;
                sqlCad.CommandText = "USP_S_DetalleVentas";
                sqlCad.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCad);
                sqlDat.Fill(dtDetalleVentas);
            }
            catch (Exception ex)
            {
                dtDetalleVentas = null;
            }
            finally
            {
                if (ClsNeConexion.con.State == ConnectionState.Open) objcon.desconectar();
            }

            return dtDetalleVentas;

        }
        public string MtdAgregarDetalleVenta(ClsEnDetalleVenta objEDetalleVenta)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            string rpta = "";

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_I_DetalleVentas";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlVenta_id = new SqlParameter();
                sqlVenta_id.ParameterName = "@venta_id";
                sqlVenta_id.SqlDbType = SqlDbType.Int;
                sqlVenta_id.Value = objEDetalleVenta.Venta_id;
                sqlCmd.Parameters.Add(sqlVenta_id);

                SqlParameter sqlButaca_id = new SqlParameter();
                sqlButaca_id.ParameterName = "@butaca_id";
                sqlButaca_id.SqlDbType = SqlDbType.Int;
                sqlButaca_id.Value = objEDetalleVenta.Butaca_id;
                sqlCmd.Parameters.Add(sqlButaca_id);


                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el DetalleVenta de forma correcta";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (ClsNeConexion.con.State == ConnectionState.Open) objcon.desconectar();
            }

            return rpta;
        }

        public string MtdModificarDetalleVenta(ClsEnDetalleVenta objEDetalleVenta)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            string rpta = "";
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_U_DetalleVentas";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlId = new SqlParameter();
                sqlId.ParameterName = "@id";
                sqlId.SqlDbType = SqlDbType.Int;
                sqlId.Value = objEDetalleVenta.Id;
                sqlCmd.Parameters.Add(sqlId);

                SqlParameter sqlVenta_id = new SqlParameter();
                sqlVenta_id.ParameterName = "@venta_id";
                sqlVenta_id.SqlDbType = SqlDbType.Int;
                sqlVenta_id.Value = objEDetalleVenta.Venta_id;
                sqlCmd.Parameters.Add(sqlVenta_id);

                SqlParameter sqlButaca_id = new SqlParameter();
                sqlButaca_id.ParameterName = "@butaca_id";
                sqlButaca_id.SqlDbType = SqlDbType.Int;
                sqlButaca_id.Value = objEDetalleVenta.Butaca_id;
                sqlCmd.Parameters.Add(sqlButaca_id);


                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el DetalleVenta de forma correcta";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (ClsNeConexion.con.State == ConnectionState.Open) objcon.desconectar();
            }
            return rpta;
        }

        public DataTable MtdBuscarDetalleVenta(string busqueda)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();
            DataTable dtDetalleVentas = new DataTable("detalleventas");
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_B_DetalleVentas";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlBusqueda = new SqlParameter();
                sqlBusqueda.ParameterName = "@busqueda";
                sqlBusqueda.Value = busqueda;
                sqlCmd.Parameters.Add(sqlBusqueda);
                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);

                sqlDat.Fill(dtDetalleVentas);
            }
            catch (Exception ex)
            {
                dtDetalleVentas = null;
            }

            return dtDetalleVentas;
        }

        public ClsEnDetalleVenta MtdObtenerDetalleVenta(int id)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            ClsEnDetalleVenta objEDetalleVenta = new ClsEnDetalleVenta();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_SID_DetalleVentas";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlId = new SqlParameter();
                sqlId.ParameterName = "@id";
                sqlId.SqlDbType = SqlDbType.Int;
                sqlId.Value = id;
                sqlCmd.Parameters.Add(sqlId);

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                if (sqlReader.Read())
                {
                    objEDetalleVenta.Id = sqlReader.GetInt32(0);
                    objEDetalleVenta.Venta_id = (int)sqlReader["venta_id"];
                    objEDetalleVenta.Butaca_id = (int)sqlReader["butaca_id"];
                }

            }
            catch (Exception ex)
            {
                objEDetalleVenta = null;
            }
            finally
            {
                if (ClsNeConexion.con.State == ConnectionState.Open) objcon.desconectar();
            }

            return objEDetalleVenta;
        }
    }
}

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
    class ClsNeTarifa
    {
        public DataTable MtdListarTarifa()
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            DataTable dtTarifas = new DataTable("tarifas");
            try
            {
                SqlCommand sqlCad = new SqlCommand();
                sqlCad.Connection = ClsNeConexion.con;
                sqlCad.CommandText = "USP_S_Tarifas";
                sqlCad.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCad);
                sqlDat.Fill(dtTarifas);
            }
            catch (Exception ex)
            {
                dtTarifas = null;
            }
            finally
            {
                if (ClsNeConexion.con.State == ConnectionState.Open) objcon.desconectar();
            }

            return dtTarifas;

        }
        public string MtdAgregarTarifa(ClsEnTarifa objETarifa)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            string rpta = "";

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_I_Tarifas";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlDia = new SqlParameter();
                sqlDia.ParameterName = "@dia";
                sqlDia.SqlDbType = SqlDbType.VarChar;
                sqlDia.Size = 50;
                sqlDia.Value = objETarifa.Dia;
                sqlCmd.Parameters.Add(sqlDia);

                SqlParameter sqlTipo = new SqlParameter();
                sqlTipo.ParameterName = "@tipo";
                sqlTipo.SqlDbType = SqlDbType.VarChar;
                sqlTipo.Size = 50;
                sqlTipo.Value = objETarifa.Tipo;
                sqlCmd.Parameters.Add(sqlTipo);

                SqlParameter sqlPrecio_general = new SqlParameter();
                sqlPrecio_general.ParameterName = "@precio_general";
                sqlPrecio_general.SqlDbType = SqlDbType.Decimal;
                sqlPrecio_general.Size = 18;
                sqlPrecio_general.Precision = 2;
                sqlPrecio_general.Value = objETarifa.Precio_general;
                sqlCmd.Parameters.Add(sqlPrecio_general);

                SqlParameter sqlPrecio_ninos = new SqlParameter();
                sqlPrecio_ninos.ParameterName = "@precio_ninos";
                sqlPrecio_ninos.SqlDbType = SqlDbType.Decimal;
                sqlPrecio_ninos.Size = 18;
                sqlPrecio_ninos.Precision = 2;
                sqlPrecio_ninos.Value = objETarifa.Precio_ninos;
                sqlCmd.Parameters.Add(sqlPrecio_ninos);

                SqlParameter sqlEstado = new SqlParameter();
                sqlEstado.ParameterName = "@estado";
                sqlEstado.SqlDbType = SqlDbType.Int;
                sqlEstado.Value = objETarifa.Estado;
                sqlCmd.Parameters.Add(sqlEstado);
                
                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el Tarifa de forma correcta";

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

        public string MtdModificarTarifa(ClsEnTarifa objETarifa)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            string rpta = "";
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_U_Tarifas";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlId = new SqlParameter();
                sqlId.ParameterName = "@id";
                sqlId.SqlDbType = SqlDbType.Int;
                sqlId.Value = objETarifa.Id;
                sqlCmd.Parameters.Add(sqlId);

                SqlParameter sqlDia = new SqlParameter();
                sqlDia.ParameterName = "@dia";
                sqlDia.SqlDbType = SqlDbType.VarChar;
                sqlDia.Size = 50;
                sqlDia.Value = objETarifa.Dia;
                sqlCmd.Parameters.Add(sqlDia);

                SqlParameter sqlTipo = new SqlParameter();
                sqlTipo.ParameterName = "@tipo";
                sqlTipo.SqlDbType = SqlDbType.VarChar;
                sqlTipo.Size = 50;
                sqlTipo.Value = objETarifa.Tipo;
                sqlCmd.Parameters.Add(sqlTipo);

                SqlParameter sqlPrecio_general = new SqlParameter();
                sqlPrecio_general.ParameterName = "@precio_general";
                sqlPrecio_general.SqlDbType = SqlDbType.Decimal;
                sqlPrecio_general.Precision = 18;
                sqlPrecio_general.Scale = 2;
                sqlPrecio_general.Value = objETarifa.Precio_general;
                sqlCmd.Parameters.Add(sqlPrecio_general);

                SqlParameter sqlPrecio_ninos = new SqlParameter();
                sqlPrecio_ninos.ParameterName = "@precio_ninos";
                sqlPrecio_ninos.SqlDbType = SqlDbType.Decimal;
                sqlPrecio_ninos.Precision = 18;
                sqlPrecio_ninos.Scale = 2;
                sqlPrecio_ninos.Value = objETarifa.Precio_ninos;
                sqlCmd.Parameters.Add(sqlPrecio_ninos);

                SqlParameter sqlEstado = new SqlParameter();
                sqlEstado.ParameterName = "@estado";
                sqlEstado.SqlDbType = SqlDbType.Int;
                sqlEstado.Value = objETarifa.Estado;
                sqlCmd.Parameters.Add(sqlEstado);


                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el Tarifa de forma correcta";
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

        public DataTable MtdBuscarTarifa(string busqueda)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();
            DataTable dtTarifas = new DataTable("tarifas");
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_B_Tarifas";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlBusqueda = new SqlParameter();
                sqlBusqueda.ParameterName = "@busqueda";
                sqlBusqueda.Value = busqueda;
                sqlCmd.Parameters.Add(sqlBusqueda);
                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);

                sqlDat.Fill(dtTarifas);
            }
            catch (Exception ex)
            {
                dtTarifas = null;
            }

            return dtTarifas;
        }

        public ClsEnTarifa MtdObtenerTarifa(int id)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            ClsEnTarifa objETarifa = new ClsEnTarifa();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_SID_Tarifas";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlId = new SqlParameter();
                sqlId.ParameterName = "@id";
                sqlId.SqlDbType = SqlDbType.Int;
                sqlId.Value = id;
                sqlCmd.Parameters.Add(sqlId);

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                if (sqlReader.Read())
                {
                    objETarifa.Id = sqlReader.GetInt32(0);
                    objETarifa.Dia = sqlReader["dia"].ToString();
                    objETarifa.Tipo = sqlReader["tipo"].ToString();
                    objETarifa.Precio_general = Decimal.Parse(sqlReader["precio_general"].ToString());
                    objETarifa.Precio_ninos = Decimal.Parse(sqlReader["precio_ninos"].ToString());
                    objETarifa.Estado = Int32.Parse(sqlReader["estado"].ToString());
                    objETarifa.Fecha_creado = sqlReader["fecha_creado"].ToString();
                    objETarifa.Fecha_modificado = sqlReader["fecha_modificado"].ToString();

                }

            }
            catch (Exception ex)
            {
                objETarifa = null;
            }
            finally
            {
                if (ClsNeConexion.con.State == ConnectionState.Open) objcon.desconectar();
            }

            return objETarifa;
        }

    }
}

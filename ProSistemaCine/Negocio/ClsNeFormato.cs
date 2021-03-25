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
    class ClsNeFormato
    {
        public DataTable MtdListarFormato()
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            DataTable dtFormatos = new DataTable("formatos");
            try
            {
                SqlCommand sqlCad = new SqlCommand();
                sqlCad.Connection = ClsNeConexion.con;
                sqlCad.CommandText = "USP_S_Formatos";
                sqlCad.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCad);
                sqlDat.Fill(dtFormatos);
            }
            catch (Exception ex)
            {
                dtFormatos = null;
            }
            finally
            {
                if (ClsNeConexion.con.State == ConnectionState.Open) objcon.desconectar();
            }

            return dtFormatos;

        }
        public string MtdAgregarFormato(ClsEnFormato objEFormato)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            string rpta = "";

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_I_Formatos";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlNombre = new SqlParameter();
                sqlNombre.ParameterName = "@nombre";
                sqlNombre.SqlDbType = SqlDbType.VarChar;
                sqlNombre.Size = 50;
                sqlNombre.Value = objEFormato.Nombre;
                sqlCmd.Parameters.Add(sqlNombre);

                SqlParameter sqlEstado = new SqlParameter();
                sqlEstado.ParameterName = "@estado";
                sqlEstado.SqlDbType = SqlDbType.Int;
                sqlEstado.Value = objEFormato.Estado;
                sqlCmd.Parameters.Add(sqlEstado);



                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el Formato de forma correcta";

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

        public string MtdModificarFormato(ClsEnFormato objEFormato)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            string rpta = "";
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_U_Formatos";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlId = new SqlParameter();
                sqlId.ParameterName = "@id";
                sqlId.SqlDbType = SqlDbType.Int;
                sqlId.Value = objEFormato.Id;
                sqlCmd.Parameters.Add(sqlId);

                SqlParameter sqlNombre = new SqlParameter();
                sqlNombre.ParameterName = "@nombre";
                sqlNombre.SqlDbType = SqlDbType.VarChar;
                sqlNombre.Size = 50;
                sqlNombre.Value = objEFormato.Nombre;
                sqlCmd.Parameters.Add(sqlNombre);

                SqlParameter sqlEstado = new SqlParameter();
                sqlEstado.ParameterName = "@estado";
                sqlEstado.SqlDbType = SqlDbType.Int;
                sqlEstado.Value = objEFormato.Estado;
                sqlCmd.Parameters.Add(sqlEstado);
                
                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el Formato de forma correcta";
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

        public DataTable MtdBuscarFormato(string busqueda)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();
            DataTable dtFormatos = new DataTable("formatos");
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_B_Formatos";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlBusqueda = new SqlParameter();
                sqlBusqueda.ParameterName = "@busqueda";
                sqlBusqueda.Value = busqueda;
                sqlCmd.Parameters.Add(sqlBusqueda);
                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);

                sqlDat.Fill(dtFormatos);
            }
            catch (Exception ex)
            {
                dtFormatos = null;
            }

            return dtFormatos;
        }

        public ClsEnFormato MtdObtenerFormato(int id)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            ClsEnFormato objEFormato = new ClsEnFormato();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_SID_Formatos";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlId = new SqlParameter();
                sqlId.ParameterName = "@id";
                sqlId.SqlDbType = SqlDbType.Int;
                sqlId.Value = id;
                sqlCmd.Parameters.Add(sqlId);

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                if (sqlReader.Read())
                {
                    objEFormato.Id = sqlReader.GetInt32(0);
                    objEFormato.Nombre = sqlReader["nombre"].ToString();
                    objEFormato.Estado = sqlReader.GetInt32(2);
                    objEFormato.Fecha_creado = sqlReader["fecha_creado"].ToString();
                    objEFormato.Fecha_modificado = sqlReader["fecha_modificado"].ToString();

                }

            }
            catch (Exception ex)
            {
                objEFormato = null;
            }
            finally
            {
                if (ClsNeConexion.con.State == ConnectionState.Open) objcon.desconectar();
            }

            return objEFormato;
        }
    }
}

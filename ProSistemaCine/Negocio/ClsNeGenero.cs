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
    class ClsNeGenero
    {
        public DataTable MtdListarGenero()
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            DataTable dtGeneros = new DataTable("generos");
            try
            {
                SqlCommand sqlCad = new SqlCommand();
                sqlCad.Connection = ClsNeConexion.con;
                sqlCad.CommandText = "USP_S_Generos";
                sqlCad.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCad);
                sqlDat.Fill(dtGeneros);
            }
            catch (Exception ex)
            {
                dtGeneros = null;
            }
            finally
            {
                if (ClsNeConexion.con.State == ConnectionState.Open) objcon.desconectar();
            }

            return dtGeneros;

        }
        public string MtdAgregarGenero(ClsEnGenero objEGenero)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            string rpta = "";

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_I_Generos";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlNombre = new SqlParameter();
                sqlNombre.ParameterName = "@nombre";
                sqlNombre.SqlDbType = SqlDbType.VarChar;
                sqlNombre.Size = 50;
                sqlNombre.Value = objEGenero.Nombre;
                sqlCmd.Parameters.Add(sqlNombre);

                SqlParameter sqlEstado = new SqlParameter();
                sqlEstado.ParameterName = "@estado";
                sqlEstado.SqlDbType = SqlDbType.Int;
                sqlEstado.Value = objEGenero.Estado;
                sqlCmd.Parameters.Add(sqlEstado);



                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el Genero de forma correcta";

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

        public string MtdModificarGenero(ClsEnGenero objEGenero)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            string rpta = "";
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_U_Generos";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlId = new SqlParameter();
                sqlId.ParameterName = "@id";
                sqlId.SqlDbType = SqlDbType.Int;
                sqlId.Value = objEGenero.Id;
                sqlCmd.Parameters.Add(sqlId);

                SqlParameter sqlNombre = new SqlParameter();
                sqlNombre.ParameterName = "@nombre";
                sqlNombre.SqlDbType = SqlDbType.VarChar;
                sqlNombre.Size = 50;
                sqlNombre.Value = objEGenero.Nombre;
                sqlCmd.Parameters.Add(sqlNombre);

                SqlParameter sqlEstado = new SqlParameter();
                sqlEstado.ParameterName = "@estado";
                sqlEstado.SqlDbType = SqlDbType.Int;
                sqlEstado.Value = objEGenero.Estado;
                sqlCmd.Parameters.Add(sqlEstado);

                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el Genero de forma correcta";
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

        public DataTable MtdBuscarGenero(string busqueda)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();
            DataTable dtGeneros = new DataTable("generos");
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_B_Generos";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlBusqueda = new SqlParameter();
                sqlBusqueda.ParameterName = "@busqueda";
                sqlBusqueda.Value = busqueda;
                sqlCmd.Parameters.Add(sqlBusqueda);
                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);

                sqlDat.Fill(dtGeneros);
            }
            catch (Exception ex)
            {
                dtGeneros = null;
            }

            return dtGeneros;
        }

        public ClsEnGenero MtdObtenerGenero(int id)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            ClsEnGenero objEGenero = new ClsEnGenero();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_SID_Generos";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlId = new SqlParameter();
                sqlId.ParameterName = "@id";
                sqlId.SqlDbType = SqlDbType.Int;
                sqlId.Value = id;
                sqlCmd.Parameters.Add(sqlId);

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                if (sqlReader.Read())
                {
                    objEGenero.Id = sqlReader.GetInt32(0);
                    objEGenero.Nombre = sqlReader["nombre"].ToString();
                    objEGenero.Estado = sqlReader.GetInt32(2);
                    objEGenero.Fecha_creado = sqlReader["fecha_creado"].ToString();
                    objEGenero.Fecha_modificado = sqlReader["fecha_modificado"].ToString();
                }

            }
            catch (Exception ex)
            {
                objEGenero = null;
            }
            finally
            {
                if (ClsNeConexion.con.State == ConnectionState.Open) objcon.desconectar();
            }

            return objEGenero;
        }
    }
}

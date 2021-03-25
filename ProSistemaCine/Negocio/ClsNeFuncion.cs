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
    class ClsNeFuncion
    {
        public DataTable MtdListarFuncion()
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            DataTable dtFunciones = new DataTable("funciones");
            try
            {
                SqlCommand sqlCad = new SqlCommand();
                sqlCad.Connection = ClsNeConexion.con;
                sqlCad.CommandText = "USP_S_Funciones";
                sqlCad.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCad);
                sqlDat.Fill(dtFunciones);
            }
            catch (Exception ex)
            {
                dtFunciones = null;
            }
            finally
            {
                if (ClsNeConexion.con.State == ConnectionState.Open) objcon.desconectar();
            }

            return dtFunciones;

        }
        public string MtdAgregarFuncion(ClsEnFuncion objEFuncion)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            string rpta = "";

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_I_Funciones";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlPelicula_id = new SqlParameter();
                sqlPelicula_id.ParameterName = "@pelicula_id";
                sqlPelicula_id.SqlDbType = SqlDbType.Int;
                sqlPelicula_id.Value = objEFuncion.Pelicula_id;
                sqlCmd.Parameters.Add(sqlPelicula_id);

                SqlParameter sqlSala_id = new SqlParameter();
                sqlSala_id.ParameterName = "@sala_id";
                sqlSala_id.SqlDbType = SqlDbType.Int;
                sqlSala_id.Value = objEFuncion.Sala_id;
                sqlCmd.Parameters.Add(sqlSala_id);

                SqlParameter sqlTarifa_id = new SqlParameter();
                sqlTarifa_id.ParameterName = "@tarifa_id";
                sqlTarifa_id.SqlDbType = SqlDbType.Int;
                sqlTarifa_id.Value = objEFuncion.Tarifa_id;
                sqlCmd.Parameters.Add(sqlTarifa_id);

                SqlParameter sqlIdioma = new SqlParameter();
                sqlIdioma.ParameterName = "@idioma";
                sqlIdioma.SqlDbType = SqlDbType.VarChar;
                sqlIdioma.Size = 10;
                sqlIdioma.Value = objEFuncion.Idioma;
                sqlCmd.Parameters.Add(sqlIdioma);

                SqlParameter sqlHora = new SqlParameter();
                sqlHora.ParameterName = "@hora";
                sqlHora.SqlDbType = SqlDbType.VarChar;
                sqlHora.Size = 10;
                sqlHora.Value = objEFuncion.Hora;
                sqlCmd.Parameters.Add(sqlHora);

                SqlParameter sqlEstado = new SqlParameter();
                sqlEstado.ParameterName = "@estado";
                sqlEstado.SqlDbType = SqlDbType.Int;
                sqlEstado.Value = objEFuncion.Estado;
                sqlCmd.Parameters.Add(sqlEstado);


                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el Funcion de forma correcta";

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

        public string MtdModificarFuncion(ClsEnFuncion objEFuncion)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            string rpta = "";
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_U_Funciones";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlId = new SqlParameter();
                sqlId.ParameterName = "@id";
                sqlId.SqlDbType = SqlDbType.Int;
                sqlId.Value = objEFuncion.Id;
                sqlCmd.Parameters.Add(sqlId);

                SqlParameter sqlPelicula_id = new SqlParameter();
                sqlPelicula_id.ParameterName = "@pelicula_id";
                sqlPelicula_id.SqlDbType = SqlDbType.Int;
                sqlPelicula_id.Value = objEFuncion.Pelicula_id;
                sqlCmd.Parameters.Add(sqlPelicula_id);

                SqlParameter sqlSala_id = new SqlParameter();
                sqlSala_id.ParameterName = "@sala_id";
                sqlSala_id.SqlDbType = SqlDbType.Int;
                sqlSala_id.Value = objEFuncion.Sala_id;
                sqlCmd.Parameters.Add(sqlSala_id);

                SqlParameter sqlTarifa_id = new SqlParameter();
                sqlTarifa_id.ParameterName = "@tarifa_id";
                sqlTarifa_id.SqlDbType = SqlDbType.Int;
                sqlTarifa_id.Value = objEFuncion.Tarifa_id;
                sqlCmd.Parameters.Add(sqlTarifa_id);

                SqlParameter sqlIdioma = new SqlParameter();
                sqlIdioma.ParameterName = "@idioma";
                sqlIdioma.SqlDbType = SqlDbType.VarChar;
                sqlIdioma.Size = 10;
                sqlIdioma.Value = objEFuncion.Idioma;
                sqlCmd.Parameters.Add(sqlIdioma);

                SqlParameter sqlHora = new SqlParameter();
                sqlHora.ParameterName = "@hora";
                sqlHora.SqlDbType = SqlDbType.VarChar;
                sqlHora.Size = 10;
                sqlHora.Value = objEFuncion.Hora;
                sqlCmd.Parameters.Add(sqlHora);

                SqlParameter sqlEstado = new SqlParameter();
                sqlEstado.ParameterName = "@estado";
                sqlEstado.SqlDbType = SqlDbType.Int;
                sqlEstado.Value = objEFuncion.Estado;
                sqlCmd.Parameters.Add(sqlEstado);

                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el Funcion de forma correcta";
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

        public DataTable MtdBuscarFuncion(string busqueda)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();
            DataTable dtFunciones = new DataTable("funciones");
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_B_Funciones";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlBusqueda = new SqlParameter();
                sqlBusqueda.ParameterName = "@busqueda";
                sqlBusqueda.Value = busqueda;
                sqlCmd.Parameters.Add(sqlBusqueda);
                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);

                sqlDat.Fill(dtFunciones);
            }
            catch (Exception ex)
            {
                dtFunciones = null;
            }

            return dtFunciones;
        }

        public ClsEnFuncion MtdObtenerFuncion(int id)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            ClsEnFuncion objEFuncion = new ClsEnFuncion();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_SID_Funciones";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlId = new SqlParameter();
                sqlId.ParameterName = "@id";
                sqlId.SqlDbType = SqlDbType.Int;
                sqlId.Value = id;
                sqlCmd.Parameters.Add(sqlId);

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                if (sqlReader.Read())
                {
                    objEFuncion.Id = sqlReader.GetInt32(0);
                    objEFuncion.Pelicula_id = Int32.Parse(sqlReader["pelicula_id"].ToString());
                    objEFuncion.Sala_id = Int32.Parse(sqlReader["sala_id"].ToString());
                    objEFuncion.Tarifa_id = Int32.Parse(sqlReader["tarifa_id"].ToString());
                    objEFuncion.Idioma = sqlReader["idioma"].ToString();
                    objEFuncion.Hora = sqlReader["hora"].ToString();
                    objEFuncion.Estado = Int32.Parse(sqlReader["estado"].ToString());
                    objEFuncion.Fecha_creado = sqlReader["fecha_creado"].ToString();
                    objEFuncion.Fecha_modificado = sqlReader["fecha_modificado"].ToString();
                }

            }
            catch (Exception ex)
            {
                objEFuncion = null;
            }
            finally
            {
                if (ClsNeConexion.con.State == ConnectionState.Open) objcon.desconectar();
            }

            return objEFuncion;
        }

        /**/
        public DataTable MtdFiltrarFuncion(int pelicula_id,string fecha, string idioma)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();
            DataTable dtFunciones = new DataTable("funciones");
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_F_Funciones";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlPelicula_id = new SqlParameter();
                sqlPelicula_id.ParameterName = "@pelicula_id";
                sqlPelicula_id.Value = pelicula_id;
                sqlCmd.Parameters.Add(sqlPelicula_id);

                SqlParameter sqlFecha = new SqlParameter();
                sqlFecha.ParameterName = "@fecha";
                sqlFecha.Value = fecha;
                sqlCmd.Parameters.Add(sqlFecha);

                SqlParameter sqlIdioma = new SqlParameter();
                sqlIdioma.ParameterName = "@idioma";
                sqlIdioma.Value = idioma;
                sqlCmd.Parameters.Add(sqlIdioma);


                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);

                sqlDat.Fill(dtFunciones);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                dtFunciones = null;
            }

            return dtFunciones;
        }
    }
}

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
    class ClsNePelicula
    {
        public DataTable MtdListarPelicula()
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            DataTable dtPeliculas = new DataTable("peliculas");
            try
            {
                SqlCommand sqlCad = new SqlCommand();
                sqlCad.Connection = ClsNeConexion.con;
                sqlCad.CommandText = "USP_S_Peliculas";
                sqlCad.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCad);
                sqlDat.Fill(dtPeliculas);
            }
            catch (Exception ex)
            {
                dtPeliculas = null;
            }
            finally
            {
                if (ClsNeConexion.con.State == ConnectionState.Open) objcon.desconectar();
            }

            return dtPeliculas;

        }
        public string MtdAgregarPelicula(ClsEnPelicula objEPelicula)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            string rpta = "";

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_I_Peliculas";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlGenero_id = new SqlParameter();
                sqlGenero_id.ParameterName = "@genero_id";
                sqlGenero_id.SqlDbType = SqlDbType.Int;
                sqlGenero_id.Value = objEPelicula.Genero_id;
                sqlCmd.Parameters.Add(sqlGenero_id);

                SqlParameter sqlNombre = new SqlParameter();
                sqlNombre.ParameterName = "@nombre";
                sqlNombre.SqlDbType = SqlDbType.VarChar;
                sqlNombre.Size = 50;
                sqlNombre.Value = objEPelicula.Nombre;
                sqlCmd.Parameters.Add(sqlNombre);

                SqlParameter sqlDescripcion = new SqlParameter();
                sqlDescripcion.ParameterName = "@descripcion";
                sqlDescripcion.SqlDbType = SqlDbType.VarChar;
                sqlDescripcion.Size = 50;
                sqlDescripcion.Value = objEPelicula.Descripcion;
                sqlCmd.Parameters.Add(sqlDescripcion);

                SqlParameter sqlDuracion = new SqlParameter();
                sqlDuracion.ParameterName = "@duracion";
                sqlDuracion.SqlDbType = SqlDbType.VarChar;
                sqlDuracion.Size = 50;
                sqlDuracion.Value = objEPelicula.Duracion;
                sqlCmd.Parameters.Add(sqlDuracion);

                SqlParameter sqlIdioma_dob = new SqlParameter();
                sqlIdioma_dob.ParameterName = "@idioma_dob";
                sqlIdioma_dob.SqlDbType = SqlDbType.Int;
                sqlIdioma_dob.Value = objEPelicula.Idioma_dob;
                sqlCmd.Parameters.Add(sqlIdioma_dob);

                SqlParameter sqlIdioma_sub = new SqlParameter();
                sqlIdioma_sub.ParameterName = "@idioma_sub";
                sqlIdioma_sub.SqlDbType = SqlDbType.Int;
                sqlIdioma_sub.Value = objEPelicula.Idioma_sub;
                sqlCmd.Parameters.Add(sqlIdioma_sub);

                SqlParameter sqlSensura_14 = new SqlParameter();
                sqlSensura_14.ParameterName = "@sensura";
                sqlSensura_14.SqlDbType = SqlDbType.Int;
                sqlSensura_14.Value = objEPelicula.Sensura;
                sqlCmd.Parameters.Add(sqlSensura_14);

                SqlParameter sqlEstado = new SqlParameter();
                sqlEstado.ParameterName = "@estado";
                sqlEstado.SqlDbType = SqlDbType.Int;
                sqlEstado.Size = 50;
                sqlEstado.Value = objEPelicula.Estado;
                sqlCmd.Parameters.Add(sqlEstado);
                

                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el Pelicula de forma correcta";

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

        public string MtdModificarPelicula(ClsEnPelicula objEPelicula)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            string rpta = "";
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_U_Peliculas";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlId = new SqlParameter();
                sqlId.ParameterName = "@id";
                sqlId.SqlDbType = SqlDbType.Int;
                sqlId.Value = objEPelicula.Id;
                sqlCmd.Parameters.Add(sqlId);

                SqlParameter sqlGenero_id = new SqlParameter();
                sqlGenero_id.ParameterName = "@genero_id";
                sqlGenero_id.SqlDbType = SqlDbType.Int;
                sqlGenero_id.Value = objEPelicula.Genero_id;
                sqlCmd.Parameters.Add(sqlGenero_id);

                SqlParameter sqlNombre = new SqlParameter();
                sqlNombre.ParameterName = "@nombre";
                sqlNombre.SqlDbType = SqlDbType.VarChar;
                sqlNombre.Size = 50;
                sqlNombre.Value = objEPelicula.Nombre;
                sqlCmd.Parameters.Add(sqlNombre);

                SqlParameter sqlDescripcion = new SqlParameter();
                sqlDescripcion.ParameterName = "@descripcion";
                sqlDescripcion.SqlDbType = SqlDbType.VarChar;
                sqlDescripcion.Size = 50;
                sqlDescripcion.Value = objEPelicula.Descripcion;
                sqlCmd.Parameters.Add(sqlDescripcion);

                SqlParameter sqlDuracion = new SqlParameter();
                sqlDuracion.ParameterName = "@duracion";
                sqlDuracion.SqlDbType = SqlDbType.VarChar;
                sqlDuracion.Size = 50;
                sqlDuracion.Value = objEPelicula.Duracion;
                sqlCmd.Parameters.Add(sqlDuracion);

                SqlParameter sqlIdioma_dob = new SqlParameter();
                sqlIdioma_dob.ParameterName = "@idioma_dob";
                sqlIdioma_dob.SqlDbType = SqlDbType.Int;
                sqlIdioma_dob.Value = objEPelicula.Idioma_dob;
                sqlCmd.Parameters.Add(sqlIdioma_dob);

                SqlParameter sqlIdioma_sub = new SqlParameter();
                sqlIdioma_sub.ParameterName = "@idioma_sub";
                sqlIdioma_sub.SqlDbType = SqlDbType.Int;
                sqlIdioma_sub.Value = objEPelicula.Idioma_sub;
                sqlCmd.Parameters.Add(sqlIdioma_sub);

                SqlParameter sqlSensura_14 = new SqlParameter();
                sqlSensura_14.ParameterName = "@sensura";
                sqlSensura_14.SqlDbType = SqlDbType.Int;
                sqlSensura_14.Value = objEPelicula.Sensura;
                sqlCmd.Parameters.Add(sqlSensura_14);

                SqlParameter sqlEstado = new SqlParameter();
                sqlEstado.ParameterName = "@estado";
                sqlEstado.SqlDbType = SqlDbType.Int;
                sqlEstado.Size = 50;
                sqlEstado.Value = objEPelicula.Estado;
                sqlCmd.Parameters.Add(sqlEstado);

                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el Pelicula de forma correcta";
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

        public DataTable MtdBuscarPelicula(string busqueda)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();
            DataTable dtPeliculas = new DataTable("peliculas");
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_B_Peliculas";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlBusqueda = new SqlParameter();
                sqlBusqueda.ParameterName = "@busqueda";
                sqlBusqueda.Value = busqueda;
                sqlCmd.Parameters.Add(sqlBusqueda);
                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);

                sqlDat.Fill(dtPeliculas);
            }
            catch (Exception ex)
            {
                dtPeliculas = null;
            }

            return dtPeliculas;
        }

        public ClsEnPelicula MtdObtenerPelicula(int id)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            ClsEnPelicula objEPelicula = new ClsEnPelicula();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_SID_Peliculas";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlId = new SqlParameter();
                sqlId.ParameterName = "@id";
                sqlId.SqlDbType = SqlDbType.Int;
                sqlId.Value = id;
                sqlCmd.Parameters.Add(sqlId);

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                if (sqlReader.Read())
                {
                    objEPelicula.Id = sqlReader.GetInt32(0);
                    objEPelicula.Genero_id = Int32.Parse(sqlReader["genero_id"].ToString());
                    objEPelicula.Nombre = sqlReader["nombre"].ToString();
                    objEPelicula.Descripcion = sqlReader["descripcion"].ToString();
                    objEPelicula.Duracion = sqlReader["duracion"].ToString();
                    objEPelicula.Idioma_dob = Int32.Parse(sqlReader["idioma_dob"].ToString());
                    objEPelicula.Idioma_sub = Int32.Parse(sqlReader["idioma_sub"].ToString());
                    objEPelicula.Sensura = Int32.Parse(sqlReader["sensura"].ToString());
                    objEPelicula.Estado = Int32.Parse(sqlReader["estado"].ToString());
                    objEPelicula.Fecha_creado = sqlReader["fecha_creado"].ToString();
                    objEPelicula.Fecha_modificado = sqlReader["fecha_modificado"].ToString();
                }

            }
            catch (Exception ex)
            {
                objEPelicula = null;
            }
            finally
            {
                if (ClsNeConexion.con.State == ConnectionState.Open) objcon.desconectar();
            }

            return objEPelicula;
        }

    }
}

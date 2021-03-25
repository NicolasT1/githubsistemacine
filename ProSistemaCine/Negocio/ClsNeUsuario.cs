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
    class ClsNeUsuario
    {
        public DataTable MtdListarUsuario()
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            DataTable dtUsuarios = new DataTable("usuarios");
            try
            {
                SqlCommand sqlCad = new SqlCommand();
                sqlCad.Connection = ClsNeConexion.con;
                sqlCad.CommandText = "USP_S_Usuarios";
                sqlCad.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCad);
                sqlDat.Fill(dtUsuarios);
            }
            catch (Exception ex)
            {
                dtUsuarios = null;
            }
            finally
            {
                if (ClsNeConexion.con.State == ConnectionState.Open) objcon.desconectar();
            }

            return dtUsuarios;

        }

        public string MtdAgregarUsuario(ClsEnUsuario objEUsuario)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            string rpta = "";

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_I_Usuarios";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlNombres = new SqlParameter();
                sqlNombres.ParameterName = "@nombres";
                sqlNombres.SqlDbType = SqlDbType.VarChar;
                sqlNombres.Size = 50;
                sqlNombres.Value = objEUsuario.Nombres;
                sqlCmd.Parameters.Add(sqlNombres);

                SqlParameter sqlApellidos = new SqlParameter();
                sqlApellidos.ParameterName = "@apellidos";
                sqlApellidos.SqlDbType = SqlDbType.VarChar;
                sqlApellidos.Size = 50;
                sqlApellidos.Value = objEUsuario.Apellidos;
                sqlCmd.Parameters.Add(sqlApellidos);

                SqlParameter sqlUsuario = new SqlParameter();
                sqlUsuario.ParameterName = "@usuario";
                sqlUsuario.SqlDbType = SqlDbType.VarChar;
                sqlUsuario.Size = 50;
                sqlUsuario.Value = objEUsuario.Usuario;
                sqlCmd.Parameters.Add(sqlUsuario);

                SqlParameter sqlPassword = new SqlParameter();
                sqlPassword.ParameterName = "@password";
                sqlPassword.SqlDbType = SqlDbType.VarChar;
                sqlPassword.Size = 50;
                sqlPassword.Value = objEUsuario.Password;
                sqlCmd.Parameters.Add(sqlPassword);

                SqlParameter sqlEmail = new SqlParameter();
                sqlEmail.ParameterName = "@email";
                sqlEmail.SqlDbType = SqlDbType.VarChar;
                sqlEmail.Size = 50;
                sqlEmail.Value = objEUsuario.Email;
                sqlCmd.Parameters.Add(sqlEmail);

                SqlParameter sqlRol = new SqlParameter();
                sqlRol.ParameterName = "@rol";
                sqlRol.SqlDbType = SqlDbType.VarChar;
                sqlRol.Size = 50;
                sqlRol.Value = objEUsuario.Rol;
                sqlCmd.Parameters.Add(sqlRol);

                SqlParameter sqlEstado = new SqlParameter();
                sqlEstado.ParameterName = "@estado";
                sqlEstado.SqlDbType = SqlDbType.Int;
                sqlEstado.Size = 50;
                sqlEstado.Value = objEUsuario.Estado;
                sqlCmd.Parameters.Add(sqlEstado);

                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el Usuario de forma correcta";

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

        public string MtdModificarUsuario(ClsEnUsuario objEUsuario)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            string rpta = "";
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_U_Usuarios";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlId = new SqlParameter();
                sqlId.ParameterName = "@id";
                sqlId.SqlDbType = SqlDbType.Int;
                sqlId.Value = objEUsuario.Id;
                sqlCmd.Parameters.Add(sqlId);

                SqlParameter sqlNombres = new SqlParameter();
                sqlNombres.ParameterName = "@nombres";
                sqlNombres.SqlDbType = SqlDbType.VarChar;
                sqlNombres.Size = 50;
                sqlNombres.Value = objEUsuario.Nombres;
                sqlCmd.Parameters.Add(sqlNombres);

                SqlParameter sqlApellidos = new SqlParameter();
                sqlApellidos.ParameterName = "@apellidos";
                sqlApellidos.SqlDbType = SqlDbType.VarChar;
                sqlApellidos.Size = 50;
                sqlApellidos.Value = objEUsuario.Apellidos;
                sqlCmd.Parameters.Add(sqlApellidos);

                SqlParameter sqlUsuario = new SqlParameter();
                sqlUsuario.ParameterName = "@usuario";
                sqlUsuario.SqlDbType = SqlDbType.VarChar;
                sqlUsuario.Size = 50;
                sqlUsuario.Value = objEUsuario.Usuario;
                sqlCmd.Parameters.Add(sqlUsuario);

                SqlParameter sqlPassword = new SqlParameter();
                sqlPassword.ParameterName = "@password";
                sqlPassword.SqlDbType = SqlDbType.VarChar;
                sqlPassword.Size = 50;
                sqlPassword.Value = objEUsuario.Password;
                sqlCmd.Parameters.Add(sqlPassword);

                SqlParameter sqlEmail = new SqlParameter();
                sqlEmail.ParameterName = "@email";
                sqlEmail.SqlDbType = SqlDbType.VarChar;
                sqlEmail.Size = 50;
                sqlEmail.Value = objEUsuario.Email;
                sqlCmd.Parameters.Add(sqlEmail);

                SqlParameter sqlRol = new SqlParameter();
                sqlRol.ParameterName = "@rol";
                sqlRol.SqlDbType = SqlDbType.VarChar;
                sqlRol.Size = 50;
                sqlRol.Value = objEUsuario.Rol;
                sqlCmd.Parameters.Add(sqlRol);

                SqlParameter sqlEstado = new SqlParameter();
                sqlEstado.ParameterName = "@estado";
                sqlEstado.SqlDbType = SqlDbType.Int;
                sqlEstado.Size = 50;
                sqlEstado.Value = objEUsuario.Estado;
                sqlCmd.Parameters.Add(sqlEstado);

                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el Usuario de forma correcta";
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

        public ClsEnUsuario MtdObtenerUsuario(int id)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            ClsEnUsuario objEUsuario = new ClsEnUsuario();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_SID_Usuarios";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlId = new SqlParameter();
                sqlId.ParameterName = "@id";
                sqlId.SqlDbType = SqlDbType.Int;
                sqlId.Value = id;
                sqlCmd.Parameters.Add(sqlId);

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                if (sqlReader.Read())
                {
                    objEUsuario.Id = sqlReader.GetInt32(0);
                    objEUsuario.Nombres = sqlReader["nombres"].ToString();
                    objEUsuario.Apellidos = sqlReader["apellidos"].ToString();
                    objEUsuario.Usuario = sqlReader["usuario"].ToString();
                    objEUsuario.Password = sqlReader["password"].ToString();
                    objEUsuario.Email = sqlReader["Email"].ToString();
                    objEUsuario.Rol = sqlReader["Rol"].ToString();
                    objEUsuario.Estado = sqlReader.GetInt32(7);
                    objEUsuario.Fecha_creado = sqlReader["Fecha_creado"].ToString();
                    objEUsuario.Fecha_modificado = sqlReader["Fecha_modificado"].ToString();
                }

            }
            catch (Exception ex)
            {
                objEUsuario = null;
            }
            finally
            {
                if (ClsNeConexion.con.State == ConnectionState.Open) objcon.desconectar();
            }

            return objEUsuario;
        }

        public ClsEnUsuario MtdLoginUsuario(string usuario, string password)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            ClsEnUsuario objEUsuario = null;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_Login_Usuarios";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlUsuario = new SqlParameter();
                sqlUsuario.ParameterName = "@usuario";
                sqlUsuario.SqlDbType = SqlDbType.VarChar;
                sqlUsuario.Size = 50;
                sqlUsuario.Value = usuario;
                sqlCmd.Parameters.Add(sqlUsuario);

                SqlParameter sqlPassword = new SqlParameter();
                sqlPassword.ParameterName = "@password";
                sqlPassword.SqlDbType = SqlDbType.VarChar;
                sqlPassword.Size = 50;
                sqlPassword.Value = password;
                sqlCmd.Parameters.Add(sqlPassword);

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                if (sqlReader.Read())
                {
                    objEUsuario = new ClsEnUsuario();

                    objEUsuario.Id = sqlReader.GetInt32(0);
                    objEUsuario.Nombres = sqlReader["nombres"].ToString();
                    objEUsuario.Apellidos = sqlReader["apellidos"].ToString();
                    objEUsuario.Usuario = sqlReader["usuario"].ToString();
                    //objEUsuario.Password = sqlReader["password"].ToString();
                    objEUsuario.Email = sqlReader["Email"].ToString();
                    objEUsuario.Rol = sqlReader["Rol"].ToString();
                    objEUsuario.Estado = (int)sqlReader["estado"];
                    objEUsuario.Fecha_creado = sqlReader["Fecha_creado"].ToString();
                    objEUsuario.Fecha_modificado = sqlReader["Fecha_modificado"].ToString();
                }

            }
            catch (Exception ex)
            {
                objEUsuario = null;
            }
            finally
            {
                if (ClsNeConexion.con.State == ConnectionState.Open) objcon.desconectar();
            }

            return objEUsuario;
        }

        public DataTable MtdBuscarUsuario(string busqueda)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();
            DataTable dtUsuarios = new DataTable("usuarios");
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_B_Usuarios";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlBusqueda = new SqlParameter();
                sqlBusqueda.ParameterName = "@busqueda";
                sqlBusqueda.Value = busqueda;
                sqlCmd.Parameters.Add(sqlBusqueda);
                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);

                sqlDat.Fill(dtUsuarios);
            }
            catch (Exception ex)
            {
                dtUsuarios = null;
            }

            return dtUsuarios;
        }

    }
}

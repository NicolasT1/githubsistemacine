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
    class ClsNeCliente
    {
        public DataSet MtdListarCliente(Boolean t)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            DataSet dtClientes = new DataSet();
            try
            {
                SqlCommand sqlCad = new SqlCommand();
                sqlCad.Connection = ClsNeConexion.con;
                sqlCad.CommandText = "USP_S_Clientes";
                sqlCad.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCad);
                sqlDat.Fill(dtClientes);
            }
            catch (Exception ex)
            {
                dtClientes = null;
            }
            finally
            {
                if (ClsNeConexion.con.State == ConnectionState.Open) objcon.desconectar();
            }

            return dtClientes;

        }
        public DataTable MtdListarCliente()
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            DataTable dtClientes = new DataTable("clientes");
            dtClientes.TableName = "db_cineDataSet";
            try
            {
                SqlCommand sqlCad = new SqlCommand();
                sqlCad.Connection = ClsNeConexion.con;
                sqlCad.CommandText = "USP_S_Clientes";
                sqlCad.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCad);
                sqlDat.Fill(dtClientes);
            }
            catch (Exception ex)
            {
                dtClientes = null;
            }
            finally
            {
                if (ClsNeConexion.con.State == ConnectionState.Open) objcon.desconectar();
            }

            return dtClientes;

        }
        public string MtdAgregarCliente(ClsEnCliente objECliente)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            string rpta = "";

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_I_Clientes";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlNombres = new SqlParameter();
                sqlNombres.ParameterName = "@nombres";
                sqlNombres.SqlDbType = SqlDbType.VarChar;
                sqlNombres.Size = 50;
                sqlNombres.Value = objECliente.Nombres;
                sqlCmd.Parameters.Add(sqlNombres);

                SqlParameter sqlApellidos = new SqlParameter();
                sqlApellidos.ParameterName = "@apellidos";
                sqlApellidos.SqlDbType = SqlDbType.VarChar;
                sqlApellidos.Size = 50;
                sqlApellidos.Value = objECliente.Apellidos;
                sqlCmd.Parameters.Add(sqlApellidos);

                SqlParameter sqlDni = new SqlParameter();
                sqlDni.ParameterName = "@dni";
                sqlDni.SqlDbType = SqlDbType.VarChar;
                sqlDni.Size = 50;
                sqlDni.Value = objECliente.Dni;
                sqlCmd.Parameters.Add(sqlDni);

                SqlParameter sqlFecha_nacimiento = new SqlParameter();
                sqlFecha_nacimiento.ParameterName = "@fecha_nacimiento";
                sqlFecha_nacimiento.SqlDbType = SqlDbType.VarChar;
                sqlFecha_nacimiento.Size = 50;
                sqlFecha_nacimiento.Value = objECliente.Fecha_nacimiento;
                sqlCmd.Parameters.Add(sqlFecha_nacimiento);

                SqlParameter sqlEmail = new SqlParameter();
                sqlEmail.ParameterName = "@email";
                sqlEmail.SqlDbType = SqlDbType.VarChar;
                sqlEmail.Size = 50;
                sqlEmail.Value = objECliente.Email;
                sqlCmd.Parameters.Add(sqlEmail);

                SqlParameter sqlDireccion = new SqlParameter();
                sqlDireccion.ParameterName = "@direccion";
                sqlDireccion.SqlDbType = SqlDbType.VarChar;
                sqlDireccion.Size = 50;
                sqlDireccion.Value = objECliente.Direccion;
                sqlCmd.Parameters.Add(sqlDireccion);

                SqlParameter sqlGenero = new SqlParameter();
                sqlGenero.ParameterName = "@genero";
                sqlGenero.SqlDbType = SqlDbType.VarChar;
                sqlGenero.Size = 50;
                sqlGenero.Value = objECliente.Genero;
                sqlCmd.Parameters.Add(sqlGenero);

                SqlParameter sqlTipo = new SqlParameter();
                sqlTipo.ParameterName = "@tipo";
                sqlTipo.SqlDbType = SqlDbType.Int;
                sqlTipo.Value = objECliente.Tipo;
                sqlCmd.Parameters.Add(sqlTipo);

                SqlParameter sqlEstado = new SqlParameter();
                sqlEstado.ParameterName = "@estado";
                sqlEstado.SqlDbType = SqlDbType.Int;
                sqlEstado.Value = objECliente.Estado;
                sqlCmd.Parameters.Add(sqlEstado);
                
                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el Cliente de forma correcta";

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

        public string MtdModificarCliente(ClsEnCliente objECliente)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            string rpta = "";
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_U_Clientes";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlId = new SqlParameter();
                sqlId.ParameterName = "@id";
                sqlId.SqlDbType = SqlDbType.Int;
                sqlId.Value = objECliente.Id;
                sqlCmd.Parameters.Add(sqlId);

                SqlParameter sqlNombres = new SqlParameter();
                sqlNombres.ParameterName = "@nombres";
                sqlNombres.SqlDbType = SqlDbType.VarChar;
                sqlNombres.Size = 50;
                sqlNombres.Value = objECliente.Nombres;
                sqlCmd.Parameters.Add(sqlNombres);

                SqlParameter sqlApellidos = new SqlParameter();
                sqlApellidos.ParameterName = "@apellidos";
                sqlApellidos.SqlDbType = SqlDbType.VarChar;
                sqlApellidos.Size = 50;
                sqlApellidos.Value = objECliente.Apellidos;
                sqlCmd.Parameters.Add(sqlApellidos);

                SqlParameter sqlDni = new SqlParameter();
                sqlDni.ParameterName = "@dni";
                sqlDni.SqlDbType = SqlDbType.VarChar;
                sqlDni.Size = 50;
                sqlDni.Value = objECliente.Dni;
                sqlCmd.Parameters.Add(sqlDni);

                SqlParameter sqlFecha_nacimiento = new SqlParameter();
                sqlFecha_nacimiento.ParameterName = "@fecha_nacimiento";
                sqlFecha_nacimiento.SqlDbType = SqlDbType.VarChar;
                sqlFecha_nacimiento.Size = 50;
                sqlFecha_nacimiento.Value = objECliente.Fecha_nacimiento;
                sqlCmd.Parameters.Add(sqlFecha_nacimiento);

                SqlParameter sqlEmail = new SqlParameter();
                sqlEmail.ParameterName = "@email";
                sqlEmail.SqlDbType = SqlDbType.VarChar;
                sqlEmail.Size = 50;
                sqlEmail.Value = objECliente.Email;
                sqlCmd.Parameters.Add(sqlEmail);

                SqlParameter sqlDireccion = new SqlParameter();
                sqlDireccion.ParameterName = "@direccion";
                sqlDireccion.SqlDbType = SqlDbType.VarChar;
                sqlDireccion.Size = 50;
                sqlDireccion.Value = objECliente.Direccion;
                sqlCmd.Parameters.Add(sqlDireccion);

                SqlParameter sqlGenero = new SqlParameter();
                sqlGenero.ParameterName = "@genero";
                sqlGenero.SqlDbType = SqlDbType.VarChar;
                sqlGenero.Size = 50;
                sqlGenero.Value = objECliente.Genero;
                sqlCmd.Parameters.Add(sqlGenero);

                SqlParameter sqlTipo = new SqlParameter();
                sqlTipo.ParameterName = "@tipo";
                sqlTipo.SqlDbType = SqlDbType.Int;
                sqlTipo.Value = objECliente.Tipo;
                sqlCmd.Parameters.Add(sqlTipo);

                SqlParameter sqlEstado = new SqlParameter();
                sqlEstado.ParameterName = "@estado";
                sqlEstado.SqlDbType = SqlDbType.Int;
                sqlEstado.Value = objECliente.Estado;
                sqlCmd.Parameters.Add(sqlEstado);
                
                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el Cliente de forma correcta";
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

        public DataTable MtdBuscarCliente(string busqueda)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();
            DataTable dtClientes = new DataTable("clientes");
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_B_Clientes";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlBusqueda = new SqlParameter();
                sqlBusqueda.ParameterName = "@busqueda";
                sqlBusqueda.Value = busqueda;
                sqlCmd.Parameters.Add(sqlBusqueda);
                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);

                sqlDat.Fill(dtClientes);
            }
            catch (Exception ex)
            {
                dtClientes = null;
            }

            return dtClientes;
        }

        public ClsEnCliente MtdObtenerCliente(int id)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            ClsEnCliente objECliente = new ClsEnCliente();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_SID_Clientes";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlId = new SqlParameter();
                sqlId.ParameterName = "@id";
                sqlId.SqlDbType = SqlDbType.Int;
                sqlId.Value = id;
                sqlCmd.Parameters.Add(sqlId);

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                if (sqlReader.Read())
                {
                    objECliente.Id = sqlReader.GetInt32(0);
                    objECliente.Nombres = sqlReader["nombres"].ToString();
                    objECliente.Apellidos = sqlReader["apellidos"].ToString();
                    objECliente.Dni = sqlReader["dni"].ToString();
                    objECliente.Fecha_nacimiento = sqlReader["fecha_nacimiento"].ToString();
                    objECliente.Email = sqlReader["email"].ToString();
                    objECliente.Direccion = sqlReader["direccion"].ToString();
                    objECliente.Genero = sqlReader["genero"].ToString();
                    objECliente.Tipo = sqlReader.GetInt32(8);
                    objECliente.Estado = sqlReader.GetInt32(9);
                    objECliente.Fecha_creado = sqlReader["fecha_creado"].ToString();
                    objECliente.Fecha_modificado = sqlReader["fecha_modificado"].ToString();

                }

            }
            catch (Exception ex)
            {
                objECliente = null;
            }
            finally
            {
                if (ClsNeConexion.con.State == ConnectionState.Open) objcon.desconectar();
            }

            return objECliente;
        }

    }
}

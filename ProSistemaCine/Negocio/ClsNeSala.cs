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
    class ClsNeSala
    {
        public DataTable MtdListarSala()
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            DataTable dtSalas = new DataTable("salas");
            try
            {
                SqlCommand sqlCad = new SqlCommand();
                sqlCad.Connection = ClsNeConexion.con;
                sqlCad.CommandText = "USP_S_Salas";
                sqlCad.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCad);
                sqlDat.Fill(dtSalas);
            }
            catch (Exception ex)
            {
                dtSalas = null;
            }
            finally
            {
                if (ClsNeConexion.con.State == ConnectionState.Open) objcon.desconectar();
            }

            return dtSalas;

        }
        public string MtdAgregarSala(ClsEnSala objESala)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            string rpta = "";

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_I_Salas";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlFormato_id = new SqlParameter();
                sqlFormato_id.ParameterName = "@formato_id";
                sqlFormato_id.SqlDbType = SqlDbType.Int;
                sqlFormato_id.Value = objESala.Formato_id;
                sqlCmd.Parameters.Add(sqlFormato_id);

                SqlParameter sqlTipo = new SqlParameter();
                sqlTipo.ParameterName = "@tipo";
                sqlTipo.SqlDbType = SqlDbType.VarChar;
                sqlTipo.Size = 50;
                sqlTipo.Value = objESala.Tipo;
                sqlCmd.Parameters.Add(sqlTipo);

                SqlParameter sqlNombre = new SqlParameter();
                sqlNombre.ParameterName = "@nombre";
                sqlNombre.SqlDbType = SqlDbType.VarChar;
                sqlNombre.Size = 50;
                sqlNombre.Value = objESala.Nombre;
                sqlCmd.Parameters.Add(sqlNombre);

                SqlParameter sqlCapacidad = new SqlParameter();
                sqlCapacidad.ParameterName = "@capacidad";
                sqlCapacidad.SqlDbType = SqlDbType.Int;
                sqlCapacidad.Value = objESala.Capacidad;
                sqlCmd.Parameters.Add(sqlCapacidad);

                SqlParameter sqlEstado = new SqlParameter();
                sqlEstado.ParameterName = "@estado";
                sqlEstado.SqlDbType = SqlDbType.Int;
                sqlEstado.Value = objESala.Estado;
                sqlCmd.Parameters.Add(sqlEstado);

                objESala.Id = Int32.Parse(sqlCmd.ExecuteScalar().ToString());

                rpta = objESala.Id > 0 ? "OK" : "No se inserto el Sala de forma correcta";

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

        public string MtdModificarSala(ClsEnSala objESala)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            string rpta = "";
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_U_Salas";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlId = new SqlParameter();
                sqlId.ParameterName = "@id";
                sqlId.SqlDbType = SqlDbType.Int;
                sqlId.Value = objESala.Id;
                sqlCmd.Parameters.Add(sqlId);

                SqlParameter sqlFormato_id = new SqlParameter();
                sqlFormato_id.ParameterName = "@formato_id";
                sqlFormato_id.SqlDbType = SqlDbType.Int;
                sqlFormato_id.Value = objESala.Formato_id;
                sqlCmd.Parameters.Add(sqlFormato_id);

                SqlParameter sqlTipo = new SqlParameter();
                sqlTipo.ParameterName = "@tipo";
                sqlTipo.SqlDbType = SqlDbType.VarChar;
                sqlTipo.Size = 50;
                sqlTipo.Value = objESala.Tipo;
                sqlCmd.Parameters.Add(sqlTipo);

                SqlParameter sqlNombre = new SqlParameter();
                sqlNombre.ParameterName = "@nombre";
                sqlNombre.SqlDbType = SqlDbType.VarChar;
                sqlNombre.Size = 50;
                sqlNombre.Value = objESala.Nombre;
                sqlCmd.Parameters.Add(sqlNombre);

                SqlParameter sqlCapacidad = new SqlParameter();
                sqlCapacidad.ParameterName = "@capacidad";
                sqlCapacidad.SqlDbType = SqlDbType.Int;
                sqlCapacidad.Value = objESala.Capacidad;
                sqlCmd.Parameters.Add(sqlCapacidad);

                SqlParameter sqlEstado = new SqlParameter();
                sqlEstado.ParameterName = "@estado";
                sqlEstado.SqlDbType = SqlDbType.Int;
                sqlEstado.Size = 50;
                sqlEstado.Value = objESala.Estado;
                sqlCmd.Parameters.Add(sqlEstado);
                
                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el Sala de forma correcta";
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

        public DataTable MtdBuscarSala(string busqueda)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();
            DataTable dtSalas = new DataTable("salas");
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_B_Salas";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlBusqueda = new SqlParameter();
                sqlBusqueda.ParameterName = "@busqueda";
                sqlBusqueda.Value = busqueda;
                sqlCmd.Parameters.Add(sqlBusqueda);
                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);

                sqlDat.Fill(dtSalas);
            }
            catch (Exception ex)
            {
                dtSalas = null;
            }

            return dtSalas;
        }

        public ClsEnSala MtdObtenerSala(int id)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            ClsEnSala objESala = new ClsEnSala();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_SID_Salas";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlId = new SqlParameter();
                sqlId.ParameterName = "@id";
                sqlId.SqlDbType = SqlDbType.Int;
                sqlId.Value = id;
                sqlCmd.Parameters.Add(sqlId);

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                if (sqlReader.Read())
                {
                    objESala.Id = sqlReader.GetInt32(0);
                    objESala.Formato_id = Int32.Parse(sqlReader["formato_id"].ToString());
                    objESala.Tipo = sqlReader["tipo"].ToString();
                    objESala.Nombre = sqlReader["nombre"].ToString();
                    objESala.Capacidad = Int32.Parse(sqlReader["capacidad"].ToString());
                    objESala.Estado = Int32.Parse(sqlReader["estado"].ToString());
                    objESala.Fecha_creado = sqlReader["fecha_creado"].ToString();
                    objESala.Fecha_modificado = sqlReader["fecha_modificado"].ToString();
                }

            }
            catch (Exception ex)
            {
                objESala = null;
            }
            finally
            {
                if (ClsNeConexion.con.State == ConnectionState.Open) objcon.desconectar();
            }

            return objESala;
        }    }
}

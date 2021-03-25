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
    class ClsNeButaca
    {
        public DataTable MtdListarButaca()
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            DataTable dtButacas = new DataTable("butacas");
            try
            {
                SqlCommand sqlCad = new SqlCommand();
                sqlCad.Connection = ClsNeConexion.con;
                sqlCad.CommandText = "USP_S_Butacas";
                sqlCad.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCad);
                sqlDat.Fill(dtButacas);
            }
            catch (Exception ex)
            {
                dtButacas = null;
            }
            finally
            {
                if (ClsNeConexion.con.State == ConnectionState.Open) objcon.desconectar();
            }

            return dtButacas;

        }
        public string MtdAgregarButaca(ClsEnButaca objEButaca)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            string rpta = "";

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_I_Butacas";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlSala_id = new SqlParameter();
                sqlSala_id.ParameterName = "@sala_id";
                sqlSala_id.SqlDbType = SqlDbType.Int;
                sqlSala_id.Value = objEButaca.Sala_id;
                sqlCmd.Parameters.Add(sqlSala_id);

                SqlParameter sqlFila = new SqlParameter();
                sqlFila.ParameterName = "@fila";
                sqlFila.SqlDbType = SqlDbType.Int;
                sqlFila.Value = objEButaca.Fila;
                sqlCmd.Parameters.Add(sqlFila);

                SqlParameter sqlColumna = new SqlParameter();
                sqlColumna.ParameterName = "@columna";
                sqlColumna.SqlDbType = SqlDbType.Int;
                sqlColumna.Value = objEButaca.Columna;
                sqlCmd.Parameters.Add(sqlColumna);

                SqlParameter sqlTipo = new SqlParameter();
                sqlTipo.ParameterName = "@tipo";
                sqlTipo.SqlDbType = SqlDbType.Int;
                sqlTipo.Value = objEButaca.Tipo;
                sqlCmd.Parameters.Add(sqlTipo);


                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el Butaca de forma correcta";

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

        public string MtdModificarButaca(ClsEnButaca objEButaca)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            string rpta = "";
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_U_Butacas";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlId = new SqlParameter();
                sqlId.ParameterName = "@id";
                sqlId.SqlDbType = SqlDbType.Int;
                sqlId.Value = objEButaca.Id;
                sqlCmd.Parameters.Add(sqlId);

                SqlParameter sqlSala_id = new SqlParameter();
                sqlSala_id.ParameterName = "@sala_id";
                sqlSala_id.SqlDbType = SqlDbType.Int;
                sqlSala_id.Value = objEButaca.Sala_id;
                sqlCmd.Parameters.Add(sqlSala_id);

                SqlParameter sqlFila = new SqlParameter();
                sqlFila.ParameterName = "@fila";
                sqlFila.SqlDbType = SqlDbType.Int;
                sqlFila.Value = objEButaca.Fila;
                sqlCmd.Parameters.Add(sqlFila);

                SqlParameter sqlColumna = new SqlParameter();
                sqlColumna.ParameterName = "@columna";
                sqlColumna.SqlDbType = SqlDbType.Int;
                sqlColumna.Value = objEButaca.Columna;
                sqlCmd.Parameters.Add(sqlColumna);

                SqlParameter sqlTipo = new SqlParameter();
                sqlTipo.ParameterName = "@tipo";
                sqlTipo.SqlDbType = SqlDbType.Int;
                sqlTipo.Value = objEButaca.Tipo;
                sqlCmd.Parameters.Add(sqlTipo);


                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el Butaca de forma correcta";
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

        public DataTable MtdBuscarButaca(string busqueda)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();
            DataTable dtButacas = new DataTable("butacas");
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_B_Butacas";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlBusqueda = new SqlParameter();
                sqlBusqueda.ParameterName = "@busqueda";
                sqlBusqueda.Value = busqueda;
                sqlCmd.Parameters.Add(sqlBusqueda);
                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);

                sqlDat.Fill(dtButacas);
            }
            catch (Exception ex)
            {
                dtButacas = null;
            }

            return dtButacas;
        }

        public ClsEnButaca MtdObtenerButaca(int id)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            ClsEnButaca objEButaca = new ClsEnButaca();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_SID_Butacas";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlId = new SqlParameter();
                sqlId.ParameterName = "@id";
                sqlId.SqlDbType = SqlDbType.Int;
                sqlId.Value = id;
                sqlCmd.Parameters.Add(sqlId);

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                if (sqlReader.Read())
                {
                    objEButaca.Id = sqlReader.GetInt32(0);
                    objEButaca.Sala_id = Int32.Parse(sqlReader["sala_id"].ToString());
                    objEButaca.Fila = Int32.Parse(sqlReader["fila"].ToString());
                    objEButaca.Columna = Int32.Parse(sqlReader["columna"].ToString());
                    objEButaca.Tipo = Int32.Parse(sqlReader["tipo"].ToString());
                }

            }
            catch (Exception ex)
            {
                objEButaca = null;
            }
            finally
            {
                if (ClsNeConexion.con.State == ConnectionState.Open) objcon.desconectar();
            }

            return objEButaca;
        }

        public List<ClsEnButaca> MtdObtenerButacaBySala(int sala_id)
        {
            List<ClsEnButaca> butacas = new List<ClsEnButaca>();

            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();
            
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_S_Butacas_Sala";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlId = new SqlParameter();
                sqlId.ParameterName = "@sala_id";
                sqlId.SqlDbType = SqlDbType.Int;
                sqlId.Value = sala_id;
                sqlCmd.Parameters.Add(sqlId);

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                while (sqlReader.Read())
                {
                    ClsEnButaca objEButaca = new ClsEnButaca();
                    objEButaca.Id = sqlReader.GetInt32(0);
                    objEButaca.Sala_id = Int32.Parse(sqlReader["sala_id"].ToString());
                    objEButaca.Fila = Int32.Parse(sqlReader["fila"].ToString());
                    objEButaca.Columna = Int32.Parse(sqlReader["columna"].ToString());
                    objEButaca.Tipo = Int32.Parse(sqlReader["tipo"].ToString());

                    butacas.Add(objEButaca);
                }

            }
            catch (Exception ex)
            {
                butacas = null;
            }
            finally
            {
                if (ClsNeConexion.con.State == ConnectionState.Open) objcon.desconectar();
            }

            return butacas;
        }

        public string MtdEliminarButacaBySala(int sala_id)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            string rpta = "";
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_D_Butacas_Sala";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlId = new SqlParameter();
                sqlId.ParameterName = "@sala_id";
                sqlId.SqlDbType = SqlDbType.Int;
                sqlId.Value = sala_id;
                sqlCmd.Parameters.Add(sqlId);

                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el Butaca de forma correcta";
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

        public List<ClsEnButaca> MtdListarButacaFunciones(int funcion_id, string fecha)
        {
            List<ClsEnButaca> butacas = new List<ClsEnButaca>();

            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_S_Butacas_Funcion";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlId = new SqlParameter();
                sqlId.ParameterName = "@funcion_id";
                sqlId.SqlDbType = SqlDbType.Int;
                sqlId.Value = funcion_id;
                sqlCmd.Parameters.Add(sqlId);

                SqlParameter sqlFecha = new SqlParameter();
                sqlFecha.ParameterName = "@fecha";
                sqlFecha.SqlDbType = SqlDbType.Date;
                sqlFecha.Value = fecha;
                sqlCmd.Parameters.Add(sqlFecha);

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                while (sqlReader.Read())
                {
                    ClsEnButaca objEButaca = new ClsEnButaca();
                    objEButaca.Id = sqlReader.GetInt32(0);
                    objEButaca.Sala_id = Int32.Parse(sqlReader["sala_id"].ToString());
                    objEButaca.Fila = Int32.Parse(sqlReader["fila"].ToString());
                    objEButaca.Columna = Int32.Parse(sqlReader["columna"].ToString());
                    objEButaca.Tipo = Int32.Parse(sqlReader["tipo"].ToString());

                    butacas.Add(objEButaca);
                }

            }
            catch (Exception ex)
            {
                butacas = null;
            }
            finally
            {
                if (ClsNeConexion.con.State == ConnectionState.Open) objcon.desconectar();
            }

            return butacas;
        }
    }
}

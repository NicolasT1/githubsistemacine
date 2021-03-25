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
    class ClsNeVenta
    {
        public DataTable MtdListarVenta()
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            DataTable dtVentas = new DataTable("ventas");
            try
            {
                SqlCommand sqlCad = new SqlCommand();
                sqlCad.Connection = ClsNeConexion.con;
                sqlCad.CommandText = "USP_S_Ventas";
                sqlCad.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCad);
                sqlDat.Fill(dtVentas);
            }
            catch (Exception ex)
            {
                dtVentas = null;
            }
            finally
            {
                if (ClsNeConexion.con.State == ConnectionState.Open) objcon.desconectar();
            }

            return dtVentas;

        }
        public string MtdAgregarVenta(ClsEnVenta objEVenta)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            string rpta = "";

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_I_Ventas";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlUsuario_id = new SqlParameter();
                sqlUsuario_id.ParameterName = "@usuario_id";
                sqlUsuario_id.SqlDbType = SqlDbType.Int;
                sqlUsuario_id.Value = objEVenta.Usuario_id;
                sqlCmd.Parameters.Add(sqlUsuario_id);

                SqlParameter sqlCliente_id = new SqlParameter();
                sqlCliente_id.ParameterName = "@cliente_id";
                sqlCliente_id.SqlDbType = SqlDbType.Int;
                sqlCliente_id.Value = objEVenta.Cliente_id;
                sqlCmd.Parameters.Add(sqlCliente_id);

                SqlParameter sqlFuncion_id = new SqlParameter();
                sqlFuncion_id.ParameterName = "@funcion_id";
                sqlFuncion_id.SqlDbType = SqlDbType.Int;
                sqlFuncion_id.Value = objEVenta.Funcion_id;
                sqlCmd.Parameters.Add(sqlFuncion_id);

                SqlParameter sqlFecha = new SqlParameter();
                sqlFecha.ParameterName = "@fecha";
                sqlFecha.SqlDbType = SqlDbType.VarChar;
                sqlFecha.Size = 50;
                sqlFecha.Value = objEVenta.Fecha;
                sqlCmd.Parameters.Add(sqlFecha);

                SqlParameter sqlCantidad = new SqlParameter();
                sqlCantidad.ParameterName = "@cantidad";
                sqlCantidad.SqlDbType = SqlDbType.Int;
                sqlCantidad.Value = objEVenta.Cantidad;
                sqlCmd.Parameters.Add(sqlCantidad);

                SqlParameter sqlCantidad_general = new SqlParameter();
                sqlCantidad_general.ParameterName = "@cantidad_general";
                sqlCantidad_general.SqlDbType = SqlDbType.Int;
                sqlCantidad_general.Value = objEVenta.Cantidad_general;
                sqlCmd.Parameters.Add(sqlCantidad_general);

                SqlParameter sqlCantidad_ninos = new SqlParameter();
                sqlCantidad_ninos.ParameterName = "@cantidad_ninos";
                sqlCantidad_ninos.SqlDbType = SqlDbType.Int;
                sqlCantidad_ninos.Value = objEVenta.Cantidad_ninos;
                sqlCmd.Parameters.Add(sqlCantidad_ninos);

                SqlParameter sqlPrecio_general = new SqlParameter();
                sqlPrecio_general.ParameterName = "@precio_general";
                sqlPrecio_general.SqlDbType = SqlDbType.Decimal;
                sqlPrecio_general.Precision = 18;
                sqlPrecio_general.Scale = 2;
                sqlPrecio_general.Value = objEVenta.Precio_general;
                sqlCmd.Parameters.Add(sqlPrecio_general);

                SqlParameter sqlPrecio_ninos = new SqlParameter();
                sqlPrecio_ninos.ParameterName = "@precio_ninos";
                sqlPrecio_ninos.SqlDbType = SqlDbType.Decimal;
                sqlPrecio_ninos.Precision = 18;
                sqlPrecio_ninos.Scale = 2;
                sqlPrecio_ninos.Value = objEVenta.Precio_ninos;
                sqlCmd.Parameters.Add(sqlPrecio_ninos);

                SqlParameter sqlPrecio_total = new SqlParameter();
                sqlPrecio_total.ParameterName = "@precio_total";
                sqlPrecio_total.SqlDbType = SqlDbType.Decimal;
                sqlPrecio_total.Precision = 18;
                sqlPrecio_total.Scale = 2;
                sqlPrecio_total.Value = objEVenta.Precio_total;
                sqlCmd.Parameters.Add(sqlPrecio_total);

                SqlParameter sqlEstado = new SqlParameter();
                sqlEstado.ParameterName = "@estado";
                sqlEstado.SqlDbType = SqlDbType.Int;
                sqlEstado.Value = objEVenta.Estado;
                sqlCmd.Parameters.Add(sqlEstado);

                objEVenta.Id = Int32.Parse(sqlCmd.ExecuteScalar().ToString());

                rpta = objEVenta.Id > 0 ? "OK" : "No se inserto la Venta de forma correcta";

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

        public string MtdModificarVenta(ClsEnVenta objEVenta)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            string rpta = "";
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_U_Ventas";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlId = new SqlParameter();
                sqlId.ParameterName = "@id";
                sqlId.SqlDbType = SqlDbType.Int;
                sqlId.Value = objEVenta.Id;
                sqlCmd.Parameters.Add(sqlId);

                SqlParameter sqlCliente_id = new SqlParameter();
                sqlCliente_id.ParameterName = "@cliente_id";
                sqlCliente_id.SqlDbType = SqlDbType.Int;
                sqlCliente_id.Size = 50;
                sqlCliente_id.Value = objEVenta.Cliente_id;
                sqlCmd.Parameters.Add(sqlCliente_id);

                SqlParameter sqlFuncion_id = new SqlParameter();
                sqlFuncion_id.ParameterName = "@funcion_id";
                sqlFuncion_id.SqlDbType = SqlDbType.Int;
                sqlFuncion_id.Size = 50;
                sqlFuncion_id.Value = objEVenta.Funcion_id;
                sqlCmd.Parameters.Add(sqlFuncion_id);

                SqlParameter sqlFecha = new SqlParameter();
                sqlFecha.ParameterName = "@fecha";
                sqlFecha.SqlDbType = SqlDbType.VarChar;
                sqlFecha.Size = 50;
                sqlFecha.Value = objEVenta.Fecha;
                sqlCmd.Parameters.Add(sqlFecha);

                SqlParameter sqlCantidad = new SqlParameter();
                sqlCantidad.ParameterName = "@cantidad";
                sqlCantidad.SqlDbType = SqlDbType.Int;
                sqlCantidad.Size = 50;
                sqlCantidad.Value = objEVenta.Cantidad;
                sqlCmd.Parameters.Add(sqlCantidad);

                SqlParameter sqlCantidad_general = new SqlParameter();
                sqlCantidad_general.ParameterName = "@cantidad_general";
                sqlCantidad_general.SqlDbType = SqlDbType.Int;
                sqlCantidad_general.Size = 50;
                sqlCantidad_general.Value = objEVenta.Cantidad_general;
                sqlCmd.Parameters.Add(sqlCantidad_general);

                SqlParameter sqlCantidad_ninos = new SqlParameter();
                sqlCantidad_ninos.ParameterName = "@cantidad_ninos";
                sqlCantidad_ninos.SqlDbType = SqlDbType.Int;
                sqlCantidad_ninos.Size = 50;
                sqlCantidad_ninos.Value = objEVenta.Cantidad_ninos;
                sqlCmd.Parameters.Add(sqlCantidad_ninos);

                SqlParameter sqlPrecio_general = new SqlParameter();
                sqlPrecio_general.ParameterName = "@precio_general";
                sqlPrecio_general.SqlDbType = SqlDbType.VarChar;
                sqlPrecio_general.Size = 50;
                sqlPrecio_general.Value = objEVenta.Precio_general;
                sqlCmd.Parameters.Add(sqlPrecio_general);

                SqlParameter sqlPrecio_ninos = new SqlParameter();
                sqlPrecio_ninos.ParameterName = "@precio_ninos";
                sqlPrecio_ninos.SqlDbType = SqlDbType.VarChar;
                sqlPrecio_ninos.Size = 50;
                sqlPrecio_ninos.Value = objEVenta.Precio_ninos;
                sqlCmd.Parameters.Add(sqlPrecio_ninos);

                SqlParameter sqlPrecio_total = new SqlParameter();
                sqlPrecio_total.ParameterName = "@precio_total";
                sqlPrecio_total.SqlDbType = SqlDbType.VarChar;
                sqlPrecio_total.Size = 50;
                sqlPrecio_total.Value = objEVenta.Precio_total;
                sqlCmd.Parameters.Add(sqlPrecio_total);

                SqlParameter sqlEstado = new SqlParameter();
                sqlEstado.ParameterName = "@estado";
                sqlEstado.SqlDbType = SqlDbType.Int;
                sqlEstado.Size = 50;
                sqlEstado.Value = objEVenta.Estado;
                sqlCmd.Parameters.Add(sqlEstado);

                SqlParameter sqlFecha_creado = new SqlParameter();
                sqlFecha_creado.ParameterName = "@fecha_creado";
                sqlFecha_creado.SqlDbType = SqlDbType.VarChar;
                sqlFecha_creado.Size = 50;
                sqlFecha_creado.Value = objEVenta.Fecha_creado;
                sqlCmd.Parameters.Add(sqlFecha_creado);

                SqlParameter sqlFecha_modificado = new SqlParameter();
                sqlFecha_modificado.ParameterName = "@fecha_modificado";
                sqlFecha_modificado.SqlDbType = SqlDbType.VarChar;
                sqlFecha_modificado.Size = 50;
                sqlFecha_modificado.Value = objEVenta.Fecha_modificado;
                sqlCmd.Parameters.Add(sqlFecha_modificado);


                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se actualizó la Venta de forma correcta";
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

        public DataTable MtdBuscarVenta(string busqueda)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();
            DataTable dtVentas = new DataTable("ventas");
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_B_Ventas";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlBusqueda = new SqlParameter();
                sqlBusqueda.ParameterName = "@busqueda";
                sqlBusqueda.Value = busqueda;
                sqlCmd.Parameters.Add(sqlBusqueda);
                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);

                sqlDat.Fill(dtVentas);
            }
            catch (Exception ex)
            {
                dtVentas = null;
            }

            return dtVentas;
        }

        public ClsEnVenta MtdObtenerVenta(int id)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            ClsEnVenta objEVenta = new ClsEnVenta();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_SID_Ventas";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlId = new SqlParameter();
                sqlId.ParameterName = "@id";
                sqlId.SqlDbType = SqlDbType.Int;
                sqlId.Value = id;
                sqlCmd.Parameters.Add(sqlId);

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                if (sqlReader.Read())
                {
                    objEVenta.Id = sqlReader.GetInt32(0);
                    objEVenta.Cliente_id = (int)sqlReader["cliente_id"];
                    /*
                    objEVenta.Funcion_id = sqlReader["funcion_id"].ToString();
                    objEVenta.Fecha = sqlReader["fecha"].ToString();
                    objEVenta.Cantidad = sqlReader["cantidad"].ToString();
                    objEVenta.Cantidad_general = sqlReader["cantidad_general"].ToString();
                    objEVenta.Cantidad_ninos = sqlReader["cantidad_ninos"].ToString();
                    objEVenta.Precio_general = sqlReader["precio_general"].ToString();
                    objEVenta.Precio_ninos = sqlReader["precio_ninos"].ToString();
                    objEVenta.Precio_total = sqlReader["precio_total"].ToString();
                    objEVenta.Estado = sqlReader["estado"].ToString();
                    objEVenta.Fecha_creado = sqlReader["fecha_creado"].ToString();
                    */
                    objEVenta.Fecha_modificado = sqlReader["fecha_modificado"].ToString();

                }

            }
            catch (Exception ex)
            {
                objEVenta = null;
            }
            finally
            {
                if (ClsNeConexion.con.State == ConnectionState.Open) objcon.desconectar();
            }

            return objEVenta;
        }

        public DataTable MtdObtenerTotalVentaDia(string fecha)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            DataTable dtVentas = new DataTable("ventas");
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_R_Ventas_Dia";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlFecha = new SqlParameter();
                sqlFecha.ParameterName = "@fecha";
                sqlFecha.SqlDbType = SqlDbType.Date;
                sqlFecha.Value = fecha;
                sqlCmd.Parameters.Add(sqlFecha);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtVentas);
            }
            catch (Exception ex)
            {
                dtVentas = null;
            }
            finally
            {
                if (ClsNeConexion.con.State == ConnectionState.Open) objcon.desconectar();
            }

            return dtVentas;
        }

        public DataTable MtdObtenerTotalVentaSemana(string fecha_inicio, string fecha_fin)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            DataTable dtVentas = new DataTable("ventas");
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_R_Ventas_Semana";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlFechaInicio = new SqlParameter();
                sqlFechaInicio.ParameterName = "@fecha_inicio";
                sqlFechaInicio.SqlDbType = SqlDbType.Date;
                sqlFechaInicio.Value = fecha_inicio;
                sqlCmd.Parameters.Add(sqlFechaInicio);

                SqlParameter sqlFechaFin = new SqlParameter();
                sqlFechaFin.ParameterName = "@fecha_fin";
                sqlFechaFin.SqlDbType = SqlDbType.Date;
                sqlFechaFin.Value = fecha_fin;
                sqlCmd.Parameters.Add(sqlFechaFin);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtVentas);
            }
            catch (Exception ex)
            {
                dtVentas = null;
            }
            finally
            {
                if (ClsNeConexion.con.State == ConnectionState.Open) objcon.desconectar();
            }

            return dtVentas;
        }

        public DataTable MtdObtenerTotalVentaMes(int anio, int mes)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            DataTable dtVentas = new DataTable("ventas");
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_R_Ventas_Mes";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlAnio = new SqlParameter();
                sqlAnio.ParameterName = "@anio";
                sqlAnio.SqlDbType = SqlDbType.Int;
                sqlAnio.Value = anio;
                sqlCmd.Parameters.Add(sqlAnio);

                SqlParameter sqlMes = new SqlParameter();
                sqlMes.ParameterName = "@mes";
                sqlMes.SqlDbType = SqlDbType.Int;
                sqlMes.Value = mes;
                sqlCmd.Parameters.Add(sqlMes);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtVentas);
            }
            catch (Exception ex)
            {
                dtVentas = null;
            }
            finally
            {
                if (ClsNeConexion.con.State == ConnectionState.Open) objcon.desconectar();
            }

            return dtVentas;
        }

        public DataTable MtdObtenerTotalVentaAnio(int anio)
        {
            ClsNeConexion objcon = new ClsNeConexion();
            objcon.conectar();

            DataTable dtVentas = new DataTable("ventas");
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = ClsNeConexion.con;
                sqlCmd.CommandText = "USP_R_Ventas_Anio";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlAnio = new SqlParameter();
                sqlAnio.ParameterName = "@anio";
                sqlAnio.SqlDbType = SqlDbType.Int;
                sqlAnio.Value = anio;
                sqlCmd.Parameters.Add(sqlAnio);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtVentas);
            }
            catch (Exception ex)
            {
                dtVentas = null;
            }
            finally
            {
                if (ClsNeConexion.con.State == ConnectionState.Open) objcon.desconectar();
            }

            return dtVentas;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSistemaCine.Negocio
{
    class ClsNeConexion
    {
        //public string Servidor = "AEPIS01";
        public string Servidor = "localhost";
        public string BasedeDatos = "db_cine";
        public string Usuario = "sa";
        public string Clave = "1234";
        public static SqlConnection con;
        public static string ConBDcadena;
        public void conectar()
        {
            try
            {
                ConBDcadena = "server=" + Servidor + ";database="
                              + BasedeDatos + ";User id=" + Usuario +
                              ";password=" + Clave + "; Trusted_Connection=True;";
                con = new SqlConnection(ConBDcadena);
                con.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void desconectar()
        {
            con.Close();
        }
    }
}

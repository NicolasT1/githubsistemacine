using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSistemaCine.Entidad
{
    class ClsEnVenta
    {
        public int Id { get; set; }
        public int Usuario_id { get; set; }
        public int Cliente_id { get; set; }
        public int Funcion_id { get; set; }
        public string Fecha { get; set; }
        public int Cantidad { get; set; }
        public int Cantidad_general { get; set; }
        public int Cantidad_ninos { get; set; }
        public decimal Precio_general { get; set; }
        public decimal Precio_ninos { get; set; }
        public decimal Precio_total { get; set; }
        public int Estado { get; set; }
        public string Fecha_creado { get; set; }
        public string Fecha_modificado { get; set; }    }
}

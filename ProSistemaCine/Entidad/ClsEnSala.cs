using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSistemaCine.Entidad
{
    class ClsEnSala
    {
        public int Id { get; set; }
        public int Formato_id { get; set; }
        public string Tipo { get; set; }
        public string Nombre { get; set; }
        public int Capacidad { get; set; }
        public int Estado { get; set; }
        public string Fecha_creado { get; set; }
        public string Fecha_modificado { get; set; }

    }
}

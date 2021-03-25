using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSistemaCine.Entidad
{
    class ClsEnFuncion
    {
        public int Id { get; set; }
        public int Pelicula_id { get; set; }
        public int Sala_id { get; set; }
        public int Tarifa_id { get; set; }
        public string Idioma { get; set; }
        public string Hora { get; set; }
        public int Estado { get; set; }
        public string Fecha_creado { get; set; }
        public string Fecha_modificado { get; set; }    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSistemaCine.Entidad
{
    class ClsEnPelicula
    {
        public int Id { get; set; }
        public int Genero_id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Duracion { get; set; }
        public int Idioma_dob { get; set; }
        public int Idioma_sub { get; set; }
        public int Sensura { get; set; }
        public int Estado { get; set; }
        public string Fecha_creado { get; set; }
        public string Fecha_modificado { get; set; }
    }
}

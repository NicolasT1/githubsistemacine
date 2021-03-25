using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSistemaCine.Entidad
{
    public class ClsEnUsuario
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public int Estado { get; set; }
        public string Fecha_creado { get; set; }
        public string Fecha_modificado { get; set; }

    }
}

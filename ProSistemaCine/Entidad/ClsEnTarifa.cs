using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSistemaCine.Entidad
{
    class ClsEnTarifa
    {
        public int Id { get; set; }
        public string Dia { get; set; }
        public string Tipo { get; set; }
        public decimal Precio_general { get; set; }
        public decimal Precio_ninos { get; set; }
        public int Estado { get; set; }
        public string Fecha_creado { get; set; }
        public string Fecha_modificado { get; set; }

    }
}

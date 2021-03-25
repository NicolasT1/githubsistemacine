using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSistemaCine.Entidad
{
    class ClsEnDetalleVenta
    {
        public int Id { get; set; }
        public int Venta_id { get; set; }
        public int Butaca_id { get; set; }
    }
}

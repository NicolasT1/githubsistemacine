using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSistemaCine.Entidad
{
    public class ClsEnButaca
    {
        public int Id { get; set; }
        public int Sala_id { get; set; }
        public int Fila { get; set; }
        public int Columna { get; set; }
        public int Tipo { get; set; }

    }
}

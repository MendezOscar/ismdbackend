using System;
using System.Collections.Generic;

namespace ismdbackend.Models
{
    public partial class Capacidad
    {
        public int IdCapacidad { get; set; }
        public int? IdProyecto { get; set; }
        public string Estado { get; set; }
        public int? Monto { get; set; }
    }
}

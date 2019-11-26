using System;
using System.Collections.Generic;

namespace ismdbackend.Models
{
    public partial class Pruebas
    {
        public int IdPrueba { get; set; }
        public int Proyecto { get; set; }
        public string Observaciones { get; set; }
    }
}

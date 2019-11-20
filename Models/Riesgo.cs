using System;
using System.Collections.Generic;

namespace ismdbackend.Models
{
    public partial class Riesgo
    {
        public int IdRiesgo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
    }
}

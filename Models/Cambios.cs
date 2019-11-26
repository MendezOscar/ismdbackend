using System;
using System.Collections.Generic;

namespace ismdbackend.Models
{
    public partial class Cambios
    {
        public int IdCambio { get; set; }
        public string Solicitante { get; set; }
        public string Razon { get; set; }
    }
}

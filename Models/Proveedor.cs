using System;
using System.Collections.Generic;

namespace ismdbackend.Models
{
    public partial class Proveedor
    {
        public int IdProveedor { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Funcionalidad { get; set; }
    }
}

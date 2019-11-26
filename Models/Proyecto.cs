using System;
using System.Collections.Generic;

namespace ismdbackend.Models
{
    public partial class Proyecto
    {
        public int IdProyecto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Solicitante { get; set; }
        public string Encargado { get; set; }
        public string Documentacion { get; set; }
    }
}

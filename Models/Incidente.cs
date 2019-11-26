using System;
using System.Collections.Generic;

namespace ismdbackend.Models
{
    public partial class Incidente
    {
        public int IdIncidente { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? Prioridad { get; set; }
        public int? IdProyecto { get; set; }
    }
}

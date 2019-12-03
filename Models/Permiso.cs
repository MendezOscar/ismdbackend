using System;
using System.Collections.Generic;

namespace ismdbackend.Models
{
    public partial class Permiso
    {
        public int IdPermiso { get; set; }
        public string Nombre { get; set; }
        public int UsuarioId { get; set; }
    }
}

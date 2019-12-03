using System;
using System.Collections.Generic;

namespace ismdbackend.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public string Clave { get; set; }
        public int? Tipo { get; set; }
    }
}

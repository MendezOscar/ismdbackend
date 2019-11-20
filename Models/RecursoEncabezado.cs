using System;
using System.Collections.Generic;

namespace ismdbackend.Models
{
    public partial class RecursoEncabezado
    {
        public RecursoEncabezado()
        {
            RecursoDetalle = new HashSet<RecursoDetalle>();
        }

        public int IdRecurso { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public int? Costo { get; set; }

        public virtual ICollection<RecursoDetalle> RecursoDetalle { get; set; }
    }
}

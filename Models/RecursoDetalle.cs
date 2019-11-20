using System;
using System.Collections.Generic;

namespace ismdbackend.Models
{
    public partial class RecursoDetalle
    {
        public int IdRecursoDet { get; set; }
        public int? IdRecurso { get; set; }
        public string Capacidad { get; set; }

        public virtual RecursoEncabezado IdRecursoNavigation { get; set; }
    }
}

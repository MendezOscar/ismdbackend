using System;
using System.Collections.Generic;

namespace ismdbackend.Models
{
    public partial class Requerimiento
    {
        public Requerimiento()
        {
            CatalogoTecnico = new HashSet<CatalogoTecnico>();
        }

        public int IdRequerimiento { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime? Fecha { get; set; }
        public string Prioridad { get; set; }
        public string Estado { get; set; }
        public string Programador { get; set; }
        public int? IdProyecto { get; set; }

        public virtual ICollection<CatalogoTecnico> CatalogoTecnico { get; set; }
    }
}

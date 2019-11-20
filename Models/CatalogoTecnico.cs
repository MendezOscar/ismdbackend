using System;
using System.Collections.Generic;

namespace ismdbackend.Models
{
    public partial class CatalogoTecnico
    {
        public CatalogoTecnico()
        {
            CatalogoCliente = new HashSet<CatalogoCliente>();
        }

        public int IdCatalogoTec { get; set; }
        public int? IdRequerimiento { get; set; }
        public string Nombre { get; set; }
        public string Detalle { get; set; }
        public string Dependencias { get; set; }

        public virtual Requerimiento IdRequerimientoNavigation { get; set; }
        public virtual ICollection<CatalogoCliente> CatalogoCliente { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ismdbackend.Models
{
    public partial class CatalogoCliente
    {
        public int IdCatalogoCliente { get; set; }
        public int? IdCatalogoTec { get; set; }
        public string Componente { get; set; }
        public string Funcionalidad { get; set; }
        public string Ayuda { get; set; }

        public virtual CatalogoTecnico IdCatalogoTecNavigation { get; set; }
    }
}

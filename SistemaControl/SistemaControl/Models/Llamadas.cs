using System;
using System.Collections.Generic;

namespace SistemaControl.Models
{
    public partial class Llamadas
    {
        public int IdLlamadas { get; set; }
        public int? IdNegocio { get; set; }
        public DateTime FechaHora { get; set; }

        public Negocios IdNegocioNavigation { get; set; }
    }
}

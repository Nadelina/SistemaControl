using System;
using System.Collections.Generic;

namespace SistemaControl.Models
{
    public partial class Negocios
    {
        public Negocios()
        {
            Llamadas = new HashSet<Llamadas>();
        }

        public int IdNegocio { get; set; }
        public string Negocio { get; set; }
        public string Direccion { get; set; }
        public string Contacto { get; set; }
        public int Telefono { get; set; }

        public ICollection<Llamadas> Llamadas { get; set; }
    }
}

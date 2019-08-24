using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaControl.Models
{
    public class ViewModelNegocioTotal
    {
        //public List<Negocios> NegociosList { get; set; } 

        public int IdNegocio { get; set; }
        public int TotalLlamadas { get; set; }
        public string Negocio { get; set; }
        public string Direccion { get; set; }
        public string Contacto { get; set; }
        public int Telefono { get; set; }
    }
}

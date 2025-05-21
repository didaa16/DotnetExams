using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Camion : Vehicule
    {
        public int Capacite { get; set; }
        public int NbrEssieux { get; set; }
    }
}

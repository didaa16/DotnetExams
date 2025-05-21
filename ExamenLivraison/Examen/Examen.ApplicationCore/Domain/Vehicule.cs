using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Vehicule
    {
        [Key]
        public string Matricule { get; set; }
        public string Couleur { get; set; }
        public string Marque { get; set; }
        public int VitesseLimite { get; set; }
        public virtual IList<Livreur> Livreurs { get; set; }  
    }
}

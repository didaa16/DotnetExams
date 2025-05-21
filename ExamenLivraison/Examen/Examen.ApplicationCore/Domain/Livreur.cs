using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Examen.ApplicationCore.Domain
{
    public class Livreur
    {
        [Key]
        public string CIN { get; set; }
        public string CodePostal { get; set; }
        public string RasseSociale { get; set; }
        public string Ville { get; set; }
        public virtual IList<Vehicule> Vehicules { get; set; }
        public virtual IList<Colis> Coliss { get; set; }
    }
}

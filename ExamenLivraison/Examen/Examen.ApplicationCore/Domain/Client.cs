using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Client
    {
        public string CodePostal { get; set; }
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Ville { get; set; }
        public virtual IList<Colis> Colis { get; set; }
    }
}

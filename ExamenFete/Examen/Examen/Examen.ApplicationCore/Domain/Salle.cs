using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Salle
    {
        [Key]
        public int IdSalle { get; set; }
        public string NomSalle { get; set; }
        public string AdresseSalle { get; set; }
        public int Capacite { get; set; }
        public double PrixParHeure { get; set; }
        public virtual IList<Fete> Fetes { get; set; }
    }
}

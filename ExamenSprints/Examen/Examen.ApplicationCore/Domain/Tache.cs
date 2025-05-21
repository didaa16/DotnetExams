using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Tache
    {
        public string Titre { get; set; }
        public EtatTache Etat { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public int SprintKey { get; set; }
        public virtual Sprint sprint { get; set; }
        public string MembreKey { get; set; }
        public virtual Membre membre { get; set; }
    }
}

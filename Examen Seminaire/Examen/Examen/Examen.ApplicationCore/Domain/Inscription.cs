using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Inscription
    {
        public DateTime DateInscription { get; set; }
        public double TauxReduction { get; set; }
        public virtual Seminaire Seminaire { get; set; }
        public int SeminaireFK { get; set; }
        public virtual Participant Participant { get; set; }
        public int ParticipantFK { get; set; }
    }
}

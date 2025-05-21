using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Industriel : Participant
    {
        public string Fonction { get; set; }
        public string NomEntreprise { get; set; }
    }
}

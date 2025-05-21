using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Examen.ApplicationCore.Domain
{
    public class Universitaire : Participant
    {
        public string Niveau { get; set; }
        public string NomInstitut { get; set; }
        public virtual Specialite Specialite { get; set; }
    }
}

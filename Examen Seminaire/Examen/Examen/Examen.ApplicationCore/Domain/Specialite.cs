using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Specialite
    {
        public int SpecialiteId { get; set; }
        public string Nom { get; set; }
        public string Abreviation { get; set; }
        public virtual IList<Universitaire> Universitaires { get; set; }
    }
}

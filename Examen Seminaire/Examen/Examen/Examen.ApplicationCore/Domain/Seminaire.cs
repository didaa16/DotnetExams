using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Seminaire
    {
        [Key]
        public int Code { get; set; }
        public string Intitule { get; set; }
        public string Lieu { get; set; }
        public double Tarif { get; set; }
        public DateTime DateSeminaire { get; set; }
        [Range(0, 100)]
        public int NombreMaximal { get; set; }
        public virtual IList<Inscription> Inscriptions { get; set; }

    }
}

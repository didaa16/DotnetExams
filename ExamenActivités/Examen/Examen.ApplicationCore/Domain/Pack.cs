using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Examen.ApplicationCore.Domain
{
    public class Pack
    {
        [Key]
        public int PackId { get; set; }
        public int NbPlaces { get; set; }
        public DateTime DateDebut { get; set; }
        public int Duree { get; set; }
        public string IntitulePack { get; set; }
        public virtual IList<Reservation> Reservations { get; set; }
        public virtual IList<Activite> Activites { get; set; }
    }
}

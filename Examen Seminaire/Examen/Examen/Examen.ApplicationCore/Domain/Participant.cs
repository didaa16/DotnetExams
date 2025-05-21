using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Participant
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Nom { get; set; }
        [StringLength(50)]
        public string Prenom { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Adresse Mail")]
        public string Email { get; set; }
        public int NumeroTelephone { get; set; }
        public virtual IList<Inscription> Inscriptions { get; set; }
        public string nomCplet { get { return Nom + " " + Prenom; } }
    }
}

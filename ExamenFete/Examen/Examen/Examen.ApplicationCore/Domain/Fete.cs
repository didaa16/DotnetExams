using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Fete
    {
        [Key]
        public int IdFete { get; set; }
        [Required(ErrorMessage = "Description du fete est obligatoire")]
        public string Description { get; set; }
        public TypeFete Type { get; set; }
        [Range(1,250)]
        public int NbInvitesMax { get; set; }
        public int Duree { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateFete { get; set; }
       public virtual Salle Salle { get; set; }
       public virtual IList<Invitation> Invitations { get; set; }
    }
}

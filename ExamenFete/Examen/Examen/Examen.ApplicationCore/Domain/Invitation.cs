using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Invitation
    {
        public DateTime DateInvitation { get; set; }
        public bool ConfirmerInvitation { get; set; }
        public int FeteFK { get; set; }
        public virtual Fete Fete { get; set; }
        public int InviteFK { get; set; }
        public virtual Invite Invite { get; set; }
    }
}

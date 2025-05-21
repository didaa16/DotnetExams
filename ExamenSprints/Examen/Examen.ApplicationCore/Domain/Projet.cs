using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Projet
    {
        [Key]
        public string Code { get; set; }
        [Required (ErrorMessage ="Question 2-a")]
        public string Titre { get; set; }
        public string Description { get; set; }
        public virtual IList<Sprint> sprints { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Conseiller
    {
        [Key]
        public int ConseillerId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public virtual IList<Client> Clients { get; set; }
    }
}

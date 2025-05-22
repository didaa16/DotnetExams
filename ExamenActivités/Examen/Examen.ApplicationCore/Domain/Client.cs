﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Client
    {
        [Key]
        public int Identifiant { get; set; }
        [Required (ErrorMessage = "Le login est requis")]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Photo { get; set; }
        public virtual IList<Reservation> Reservations { get; set; }
        public virtual Conseiller Conseiller { get; set; }
        public int ConseillerFK { get; set; }
    }
}

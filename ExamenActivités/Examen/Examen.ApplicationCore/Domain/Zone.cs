﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Examen.ApplicationCore.Domain
{
    [Owned]
    public class Zone
    {
        public string Ville { get; set; }
        public string Pays { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen.ApplicationCore.Domain;

namespace Examen.ApplicationCore.Interfaces
{
    public interface ITacheService : IService<Tache>
    {
        int nbrTache(string matricule);
        int moyenneTache(DateTime dd, DateTime df);
        IList<Tache> tachesParProjet(string matricule);
    }
}

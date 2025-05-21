using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen.ApplicationCore.Domain;

namespace Examen.ApplicationCore.Interfaces
{
    public interface IFeteService : IService<Fete>
    {
        Salle getMostUsedSalleInThisYear();
        int getNumberOfFetesByTypeAndSalle(TypeFete typeFete, Salle salle);
        int getMostLongFete();
    }
}

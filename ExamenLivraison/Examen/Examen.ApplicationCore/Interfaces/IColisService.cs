using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen.ApplicationCore.Domain;

namespace Examen.ApplicationCore.Interfaces
{
    public interface IColisService : IService<Colis>
    {
        IList<Colis> GetAllColisByLivreur(Livreur livreur);
        double getPoidsOfColis(Livreur livreur);
    }
}

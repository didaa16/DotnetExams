using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using Exmaen.ApplicationCore.Services;

namespace Examen.ApplicationCore.Services
{
    public class ColisService : Service<Colis>, IColisService
    {
        public ColisService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IList<Colis> GetAllColisByLivreur(Livreur livreur)
        {
            return (IList<Colis>)GetAll().Where(c => c.Livreur == livreur).GroupBy(c => c.Client).ToList();
        }

        public double getPoidsOfColis(Livreur livreur)
        {
            return GetAll()
                .Where(c => c.Livreur == livreur)
                .Where(c => c.DateLivraison >= DateTime.Now.AddDays(+7))
                .Sum(c => c.Poids);
        }

    }
}

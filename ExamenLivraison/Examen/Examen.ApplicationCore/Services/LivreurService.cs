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
    public class LivreurService : Service<Livreur>, ILivreurService
    {
        private readonly ColisService _colisService;
        public LivreurService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public IList<Vehicule> getVehicule(Livreur livreur)
        {
            double poids = _colisService.getPoidsOfColis(livreur);
            if (poids < 50)
            {
                return (IList<Vehicule>)GetAll()
                    .Where(l => l == livreur)
                    .SelectMany(l => l.Vehicules)
                    .OfType<Voiture>()
                    .ToList();
            }
            else
            {
                return (IList<Vehicule>)GetAll()
                    .Where(l => l == livreur)
                    .SelectMany(l => l.Vehicules)
                    .OfType<Camion>()
                    .Where(c => c.Capacite >= poids)
                    .OrderByDescending(c => c.Capacite)
                    .Take(5)
                    .ToList();
            }
        }
    }
}

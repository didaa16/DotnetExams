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
    public class ReservationsService : Service<Reservation>, IReservationsService
    {
        public ReservationsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public double getTotalPayementsOfClient(Client client)
        {
            IList<Pack> pack = GetAll()
                .Where(r => r.Client == client)
                .Select(r => r.Pack)
                .ToList();
            double total = 0;
            for (int i = 0; i < pack.Count; i++)
            {
                total = pack[i].Activites.Sum(a => a.Prix);
            }
            return total;
        }
        public int getNumberOfReservationsForAClient(Client client)
        {
            return GetAll()
                .Where(r => r.Client == client && r.DateReservation.Year == DateTime.Now.Year)
                .Count();
        }

        public double getTotalPriceOfPack(Pack pack)
        {
            return pack.Activites.Sum(a => a.Prix);
        }

        public float getPorcentageOfPackMoreThanOneWeek()
        {
            double longDuree = GetAll()
                .Where(r => r.Pack.Duree > 7)
                .Count();
            return (float)(longDuree / GetAll().Count()) * 100;
        }
    }
}

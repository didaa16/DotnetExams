using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen.ApplicationCore.Domain;

namespace Examen.ApplicationCore.Interfaces
{
    public interface IReservationsService : IService<Reservation>
    {
        double getTotalPayementsOfClient(Client client);
        int getNumberOfReservationsForAClient(Client client);
        double getTotalPriceOfPack(Pack pack);
        float getPorcentageOfPackMoreThanOneWeek();
    }
}

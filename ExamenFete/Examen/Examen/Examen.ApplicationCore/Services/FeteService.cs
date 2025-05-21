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
    public class FeteService : Service<Fete>, IFeteService
    {
        public FeteService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Salle getMostUsedSalleInThisYear()
        {
            return GetAll()
                .Where(f => f.DateFete.Year == DateTime.Now.Year && f.Salle != null)
                .GroupBy(f => f.Salle)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .First();
        }

        public int getNumberOfFetesByTypeAndSalle(TypeFete typeFete, Salle salle)
        {
            return GetAll()
                .Where(f => f.Type == typeFete && f.Salle == salle)
                .Count();
        }

        public int getMostLongFete()
        {
            return GetAll()
                .Where(f => f.Type == TypeFete.Anniversaire)
                .Select(f => f.Duree)
                .Max();
        }
    }
}

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
    internal class InscriptionService : Service<Inscription>, IInscriptionService
    {
        public InscriptionService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IList<Participant> GetParticipantsBySeminaire(Seminaire seminaire)
        {
            return GetAll().Where(i => i.Seminaire == seminaire).Select(i => i.Participant).ToList();
        }

        public IList<Specialite> getSpecialiteOfUniversitairesBySeminaireAndDate(Seminaire seminaire, DateTime date)
        {
            return GetAll()
                .Where(i => i.Seminaire == seminaire && i.Seminaire.DateSeminaire == date)
                .Select(i => i.Participant)
                .OfType<Universitaire>()
                .Select(u => u.Specialite)
                .Distinct()
                .ToList();
        }

        public double getNumberOfParticipantUniveristairesForAllSeminairesByDate(DateTime date)
        {
            var nb = GetAll().Where(i => i.Seminaire.DateSeminaire.Year == date.Year)
                .Select(i => i.Participant)
                .OfType<Universitaire>()
                .Count();
            return nb / GetAll().Where(i => i.Seminaire.DateSeminaire.Year == date.Year)
                .Select(i => i.Participant)
                .Count();
        }
    }
}

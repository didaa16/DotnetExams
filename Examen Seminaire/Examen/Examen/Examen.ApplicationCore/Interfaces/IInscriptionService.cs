using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen.ApplicationCore.Domain;

namespace Examen.ApplicationCore.Interfaces
{
    public interface IInscriptionService : IService<Inscription>
    {
        IList<Participant> GetParticipantsBySeminaire(Seminaire seminaire);
        IList<Specialite> getSpecialiteOfUniversitairesBySeminaireAndDate(Seminaire seminaire, DateTime date);
        double getNumberOfParticipantUniveristairesForAllSeminairesByDate(DateTime date);
    }
}

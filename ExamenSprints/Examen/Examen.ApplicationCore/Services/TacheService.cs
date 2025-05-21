using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;

namespace Examen.ApplicationCore.Services
{
    public class TacheService : Service<Tache>, ITacheService
    {
        public TacheService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public int nbrTache(string matricule)
        {
            return GetAll()
                .Where(x => x.membre.Matricule == matricule && x.Etat == EtatTache.EnCours)
                .Count();
        }
        public int moyenneTache(DateTime dd, DateTime df)
        {
            return (int)GetAll()
                .Where(x => x.Etat == EtatTache.Fermee && x.DateDebut >= dd && x.DateFin <= df)
                .Average(x => (x.DateFin - x.DateDebut).TotalDays);
        }


        public IList<Tache> tachesParProjet(string matricule)
        {
            return (IList<Tache>)GetAll()
                .GroupBy(x => x.sprint.projet.Titre).ToList();
        }
    }
}

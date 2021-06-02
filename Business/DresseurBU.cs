using Fr.EQL.AI109.TPPokemon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.TPPokemon.Business
{
    public class DresseurBU
    {
        public void InsererDresseur(Dresseur d)
        {
            // age au moins 12 ans :
            if (d.DateDeNaissance.AddYears(12) > DateTime.Now)
            {
                throw new Exception("Dresseur non valide : Age inférieur à 12 ans");
            }                        
            
            // TODO : insérer le dresseur (DataAccess)

            // Exemples manipulations dates & durées :

            // TimeSpan duree = DateTime.Now - d.DateDeNaissance;
            // double age = duree / 365.25;

            // 2 jours 3heures 12minutes secondes millisecondes ticks
            // duree.TotalHours; // 51,25
            // duree.Hours; // 3
        }

    }
}

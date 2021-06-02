
using Fr.EQL.AI109.TPPokemon.Business;
using Fr.EQL.AI109.TPPokemon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.TPPokemon.Presentation
{
    class GestionDresseur
    {
        public void Ajouter()
        {
            Console.WriteLine("Création d'un nouveau dresseur");
            Console.WriteLine("-----------------------------");

            bool succes = false;

            do
            {
                try
                {
                    // récupération des informations saisies :

                    Console.Write("Saisissez un nom : ");
                    string nom = Console.ReadLine();

                    Console.Write("Saisissez un prénom : ");
                    string prenom = Console.ReadLine();

                    //Console.Write("Saisissez une date de naissance : ");
                    //DateTime dateNaissance = DateTime.Parse(Console.ReadLine()); 

                    Console.Write("Saisissez un jour de naissance : ");
                    int jour = int.Parse(Console.ReadLine());
                    Console.Write("Saisissez un mois de naissance : ");
                    int mois = int.Parse(Console.ReadLine());
                    Console.Write("Saisissez une année de naissance : ");
                    int annee = int.Parse(Console.ReadLine());

                    DateTime dateNaissance = new(annee, mois, jour);

                    Dresseur d = new Dresseur();
                    d.Nom = nom;
                    d.Prenom = prenom;
                    d.DateDeNaissance = dateNaissance;

                    // passage au business :
                    DresseurBU bu = new();

                    bu.InsererDresseur(d);
                    Console.WriteLine("Dresseur ajouté avec succès");
                    succes = true;
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                    Console.WriteLine(exc.StackTrace);
                }
            } while (succes == false);

        }

    }
}

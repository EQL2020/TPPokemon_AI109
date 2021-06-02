using System;
using System.Collections.Generic;
using Fr.EQL.AI109.TPPokemon.Business;
using Fr.EQL.AI109.TPPokemon.Model;

namespace Fr.EQL.AI109.TPPokemon.Presentation
{
    class GestionPokemon
    {
        public void Ajouter()
        {
            Console.WriteLine("Création d'un nouveau pokemon");
            Console.WriteLine("-----------------------------");

            // récupération des informations saisies :

            Console.Write("Saisissez un nom : ");
            string nom = Console.ReadLine();

            Console.WriteLine("Saisissez une taille : ");
            float taille = float.Parse(Console.ReadLine());

            // créer une instance de pokemon :

            //Pokemon p2 = new Pokemon(nom, taille, DateTime.Now, 0);

            Pokemon p = new Pokemon();
            p.Nom = nom;
            p.Taille = taille;
            p.DateCreation = DateTime.Now; // date/heure courante

            // envoyer le pokemon au business pour validation et insertion :
            PokemonBU bu = new PokemonBU();
            bu.InsererPokemon(p);

            Console.WriteLine("Pokemon inséré avec succès");
        }

        public void AffichezLesTous()
        {
            PokemonBU bu = new PokemonBU();
            List<Pokemon> pokemons = bu.GetPokemons();

            Console.WriteLine("<ul>");
            foreach (Pokemon p in pokemons)
            {
                Console.WriteLine("<li>");
                Console.WriteLine(p.Nom);
                Console.WriteLine("</li>");
            }
            Console.WriteLine("</ul>");

        }
    }
}

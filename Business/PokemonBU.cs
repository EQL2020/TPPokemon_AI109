using Fr.EQL.AI109.TPPokemon.DataAccess;
using Fr.EQL.AI109.TPPokemon.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.TPPokemon.Business
{
    public class PokemonBU
    {

        public void InsererPokemon(Pokemon p)
        {
            // vérification des règles de gestion :
            
            // taille <= taille max :
            if (p.Taille > Pokemon.TAILLE_MAX)
            {
                throw new Exception("Erreur de création de pokemon : Taille supérieur à la limite");
            }

            // tout est ok : 

            // envoyer au DataAccess pour insertion
            PokemonDAO dao = new PokemonDAO();
            dao.Create(p);
        }

        public List<Pokemon> GetPokemons()
        {
            if (DateTime.Now.Hour < 8)
            {
                throw new Exception("Consultation impossible avant 8h");
            }
            //return new PokemonDAO().GetAll();
            PokemonDAO dao = new PokemonDAO();
            return dao.GetAll();
        }

        public List<Pokemon> GetPokemons(DateTime dateCreationMin)
        {
            //return new PokemonDAO().GetAll();
            PokemonDAO dao = new PokemonDAO();
            return dao.GetByDateCreationMinimum(dateCreationMin);
        }


        public Pokemon GetPokemon(int id)
        {
            if (id <= 0)
            {
                throw new Exception("l'identifiant doit être positif");
            }

            return new PokemonDAO().GetById(id);
        }



    }
}

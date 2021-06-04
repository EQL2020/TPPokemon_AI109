using Fr.EQL.AI109.TPPokemon.Business;
using Fr.EQL.AI109.TPPokemon.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationWeb.Controllers
{
    public class PokemonController : Controller
    {

        // liste des pokemons
        // /Pokemon
        // /Pokemon/Index
        // Attributes :
        [Route("pokedex")]
        public IActionResult Index()
        {
            // Action : Index
            // Controller : PokemonController 
            // View : Pokemon/index.cshtml
            // Model : Liste de Pokemons

            // récupérer le modèles (données à afficher)
            PokemonBU bu = new PokemonBU();
            List<Pokemon> pokemons = bu.GetPokemons();

            // je charge la vue en lui passant le modèle
            // en paramètre :
            return View(pokemons);
        }

        // pokedex/cree-depuis/2021-05-31
        [Route("pokedex/cree-depuis/{dateMin:DateTime}")]
        public IActionResult GetByDateMin(DateTime dateMin)
        {
            PokemonBU bu = new PokemonBU();
            List<Pokemon> pokemons = bu.GetPokemons(dateMin);

            return View("Index", pokemons);
        }

        // pokedex/42
        [Route("pokedex/{id:int}")]
        public IActionResult Details(int id)
        {
            PokemonBU bu = new PokemonBU();
            Pokemon p = bu.GetPokemon(id);

            return View(p);
        }



        #region VIEUX CODE DE DEMO
        public EmptyResult AncienneVersion()
        {
            // récupérer les données à afficher
            PokemonBU bu = new PokemonBU();
            List<Pokemon> pokemons = bu.GetPokemons();

            // affichage :
            Response.ContentType = "text/html;charset=UTF-8";
            
            Response.WriteAsync("<!DOCTYPE html>");
            Response.WriteAsync("<html lang=fr>");
            Response.WriteAsync("<head>");
            Response.WriteAsync("<meta charset='UTF-8'>");
            Response.WriteAsync("<title>Mes pokemons de ouf</title>");
            Response.WriteAsync("</head>");
            Response.WriteAsync("<body>");
            Response.WriteAsync("<h1>MES POKEMONS</h1>");
            Response.WriteAsync("<ul>");

            foreach (Pokemon p in pokemons)
            {
                Response.WriteAsync("<li>");
                
                Response.WriteAsync(string.Format("{0} - {1:0.00} m - créé le {2:dddd d MMMM yyyy}", p.Nom, p.Taille, p.DateCreation));
                // equivaut à : 
                //Response.WriteAsync(p.Nom + " - " + p.Taille + " m");

                Response.WriteAsync("</li>");
            }

            Response.WriteAsync("</ul>");
            Response.WriteAsync("</body>");
            Response.WriteAsync("</html>");

            return new EmptyResult();
        }
        #endregion
    }
}

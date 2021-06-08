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
        //affichage en mode édition :
        [HttpGet]
        [Route("pokedex/editer/{id:int}")]
        public IActionResult Update(int id)
        {
            PokemonBU bu = new PokemonBU();
            Pokemon p = bu.GetPokemon(id);

            List<Categorie> categories = bu.GetCategories();
            ViewBag.Categories = categories;

            return View("Edition", p);
        }


        [HttpPost]
        [Route("pokedex/editer/{id:int}")]
        public IActionResult Update(Pokemon p)
        {
            PokemonBU bu = new PokemonBU();
            
            if (ModelState.IsValid)
            {
                bu.MettreAJourPokemon(p);
                return View("Bravo");
            }
            else
            {
                List<Categorie> categories = bu.GetCategories();
                ViewBag.Categories = categories;
                return View("Edition");
            }
        }

        [HttpPost]
        public IActionResult Supprimer(Pokemon p)
        {
            new PokemonBU().SupprimerPokemon(p.Id.Value);
            return RedirectToAction("Index", "Pokemon");
            //return View("Bravo");
        }

        //création d'un pokemon :
        [HttpGet]
        [Route("pokedex/nouveau")]
        public IActionResult Nouveau()
        {
            PokemonBU bu = new PokemonBU();

            List<Categorie> categories = bu.GetCategories();
            ViewBag.Categories = categories;

            return View("Edition");
        }

        // Corps de la requete :
        //    Nom:bidule
        //    Taille:1.45
        //    DateCreation:17/02/2021
        // ASP.NET >>> instancier un pokemon avec les valeurs postées
        [HttpPost] // spécifier que cette action correspond à une requete POST
        [Route("pokedex/nouveau")]
        public IActionResult Nouveau(Pokemon p)
        {
            PokemonBU bu = new PokemonBU();
            if (ModelState.IsValid) // validation du formulaire
            {
                bu.InsererPokemon(p);
                return View("Bravo");
            }
            else
            {
                List<Categorie> categories = bu.GetCategories();
                ViewBag.Categories = categories;
                return View("Edition");
            }
        }


        // liste des pokemons
        // Attributes :
        [Route("pokedex")] // http://localhost/pokedex
        public IActionResult Index()
        {
            // Action : Index
            // Controller : PokemonController 
            // View : Pokemon/index.cshtml
            // Model : Liste de Pokemons

            // récupérer le modèles (données à afficher)
            PokemonBU bu = new PokemonBU();
            List<PokemonDetail> pokemons = bu.GetAllWithDetails();

            // je charge la vue en lui passant le modèle
            // en paramètre :
            return View(pokemons);
        }

        // pokedex/cree-depuis/2021-06-03
        [Route("pokedex/cree-depuis/{dateMin:DateTime}")]
        public IActionResult GetByDateMin(DateTime dateMin)
        {
            PokemonBU bu = new PokemonBU();
            List<Pokemon> pokemons = bu.GetPokemons(dateMin);

            return View("Index", pokemons);
        }


        // localhost/pokedex/42
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

using Fr.EQL.AI109.TPPokemon.Business;
using Fr.EQL.AI109.TPPokemon.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class PlopController : Controller
    {
        // GET: PlopController
        public ActionResult Index()
        {
            List<Pokemon> pokemons = new PokemonBU().GetList();

            //ViewBag.Pokemons = pokemons;

            return View(pokemons);
        }

        // GET: PlopController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PlopController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlopController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlopController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PlopController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlopController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PlopController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

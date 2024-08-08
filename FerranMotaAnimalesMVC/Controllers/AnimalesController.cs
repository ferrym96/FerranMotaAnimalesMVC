using FerranMotaAnimalesMVC.DAL;
using FerranMotaAnimalesMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FerranMotaAnimalesMVC.Controllers
{
    public class AnimalesController : Controller
    {
        // GET: Animales
        private AnimalDAL animalDal;

        private TipoAnimalDAL tipoAnimalDal;
        public ActionResult IndexAnimales()
        {
            animalDal = new AnimalDAL();

            List<Animal> listAnimal = animalDal.SelectAll();

            Random random = new Random();

            int indiceAleatorio = random.Next(listAnimal.Count);

            string elementoAleatorio = listAnimal[indiceAleatorio].NombreAnimal;

            ViewBag.Message = "Tu animal favorito es " + elementoAleatorio;

            return View(listAnimal);
        }


        [HttpGet]
        public ActionResult FormularioAnimales()
        {
            tipoAnimalDal = new TipoAnimalDAL();

            List<TipoAnimal> listTipoAnimal = tipoAnimalDal.SelectAll();

            ViewBag.ListTipoAnimal = new SelectList(listTipoAnimal, "IdTipoAnimal", "TipoDescripcion");

            return View();
        }

        [HttpPost]
        public ActionResult FormularioAnimales(Animal model)
        {
            animalDal = new AnimalDAL();

            if (ModelState.IsValid)
            {
                Animal animal = new Animal(0, model.NombreAnimal, model.Raza,
                    model.RIdTipoAnimal, model.FechaNacimiento);

                animalDal.insertAnimal(animal);

                return RedirectToAction("IndexAnimales", "Animales");
            }
            return View(model);
        }




        [HttpGet]
        public ActionResult EliminarAnimales()
        {
            animalDal = new AnimalDAL();

            List<Animal> listAnimal = animalDal.SelectAll();

            ViewBag.ListAnimal = new SelectList(listAnimal, "IdAnimal", "NombreAnimal");

            return View();
        }


        [HttpPost]
        public ActionResult EliminarAnimales(Animal model)
        {
            animalDal = new AnimalDAL();

            if (ModelState.IsValid)
            {
                animalDal.DeleteAnimalByName(model.IdAnimal);

                return RedirectToAction("IndexAnimales", "Animales");
            }

            return View(model);
        }

    }
}
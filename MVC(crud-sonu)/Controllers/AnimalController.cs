using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_crud_sonu_.Context;
using MVC_crud_sonu_.DAL;
using MVC_crud_sonu_.Models;

namespace MVC_crud_sonu_.Controllers
{
    public class AnimalController : Controller
    {

        private readonly IAnimalRepository _animalRepository;


        public AnimalController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<IActionResult> AnimalTable(int pageNumber = 1, int rowsOfPage = 10)
        {
            List<Animal> data = await _animalRepository.GetAnimalList(pageNumber, 10);
            ViewBag.AniamlList = data;
            return View();
        }


        public async Task<List<Animal>> GetAnimalTable(int pageNumber = 1, int rowsOfPage = 10)
        {
            List<Animal> data = await _animalRepository.GetAnimalList(pageNumber, 10);
            return data;
        }


        public async Task<IActionResult> DeleteAnimal(int id)
        {
           await _animalRepository.DeleteAnimal(id);
            return RedirectToAction("AnimalTable");
        }

        public  async Task<IActionResult>  AnimalForm(int id)
        {
            Animal record = await _animalRepository.ShowEditRecord(id);
            return View(record);
        }

        [HttpPost]
        public async Task<IActionResult> AnimalForm(Animal modal)
        {
           await _animalRepository.SaveAnimal(modal);
            return RedirectToAction("AnimalTable");
        }

    }
}

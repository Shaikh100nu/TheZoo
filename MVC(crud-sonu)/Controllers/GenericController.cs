using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVC_crud_sonu_.DAL;
using MVC_crud_sonu_.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVC_crud_sonu_.Controllers
{
    public class GenericController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public GenericController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index(string jobTitle)
        {
                var data = await _unitOfWork.AnimalRepository.GetData();

                ViewBag.Modelos  = data;

                return View();
        }

        public async Task<IActionResult> AddSaveForm(string IsEditOrAdd)
        {

            return View();
        }

        public async Task<IActionResult> SaveAnimalData(Animal _animal)
        {

             await _unitOfWork.AnimalRepository.SaveData(_animal);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteAnimaData(int id)
        {
            await _unitOfWork.AnimalRepository.DeleteAnimalData(id);

            return RedirectToAction("Index");
        }

    }
}

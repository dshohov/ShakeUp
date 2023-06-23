using Microsoft.AspNetCore.Mvc;
using ShakeUp.Helpers;
using ShakeUp.Interfaces;
using ShakeUp.Models;
using ShakeUp.ViewModels;

namespace ShakeUp.Controllers
{
    public class AlcoholController : Controller
    {
        private readonly IAlcoholRepository _alcoholRepository;
        public AlcoholController(IAlcoholRepository alcoholRepository)
        {
            _alcoholRepository = alcoholRepository;
        }

        public IActionResult Index(int? sortType)
        {
            int actualSortType = sortType ?? 1;
            var a = actualSortType == 1 ? _alcoholRepository.SortNameAtoZ() : _alcoholRepository.SortNameZtoA();

            return View(a);
        }
        public IActionResult CreateAlcohol()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateAlcohol(AlcoholVM alcoholVM, IFormFile fileUpload)
        {
            Alcohol alcohol = new Alcohol()
            {
                Name = alcoholVM.Name,
                Description = alcoholVM.Description,
                Type = _alcoholRepository.ChooseStrength(alcoholVM.Degree),
                Degree = alcoholVM.Degree,
                Photo = PhotoHelp.GetBytesPhoto(fileUpload),
                BackgroundColor = alcoholVM.BackgroundColor
            };
            if(alcohol.Photo != null)
            {
                _alcoholRepository.Add(alcohol);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Please send only svg photo";
            }
            return View();
        }
    }
}

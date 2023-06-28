using Microsoft.AspNetCore.Mvc;
using ShakeUp.Data.Enum;
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
        public IActionResult Index(int filterType = 0)
        {
            var alcohols = filterType == 0 ? _alcoholRepository.GetAllAlcohols() 
                                           : _alcoholRepository.FilterType(filterType);
            return View(alcohols);
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
            if (alcohol.Photo != null)
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
        [HttpGet]
        public IActionResult UpdateAlcohol(int id)
        {

            return View(_alcoholRepository.GetAlcoholById(id));
        }
        [HttpPost]
        public IActionResult UpdateAlcohol(AlcoholVM alcoholVM, IFormFile fileUpload)
        {
            Alcohol alcohol = _alcoholRepository.GetAlcoholById(alcoholVM.Id);
            if (alcohol != null)
            {
                alcohol.Name = alcoholVM.Name;
                alcohol.Description = alcoholVM.Description;
                alcohol.Degree = alcoholVM.Degree;
                alcohol.Photo = fileUpload == null ? alcohol.Photo : PhotoHelp.GetBytesPhoto(fileUpload);
                alcohol.Type = _alcoholRepository.ChooseStrength(alcoholVM.Degree);
                alcohol.BackgroundColor = alcoholVM.BackgroundColor;
                _alcoholRepository.Update(alcohol);
                return RedirectToAction("Index", "Alcohol");
            }
            return View(alcohol);
        }
        public IActionResult DeleteAlcohol(int id)
        {
            _alcoholRepository.Delete(_alcoholRepository.GetAlcoholById(id));
            return RedirectToAction("Index", "Alcohol");
        }        
    }
    
}

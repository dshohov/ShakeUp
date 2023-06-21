using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateAlcohol()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateAlcohol(AlcoholVM alcoholVM, IFormFile fileUpload)
        {
            if (fileUpload != null && fileUpload.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    fileUpload.CopyTo(memoryStream);
                    byte[] fileBytes = memoryStream.ToArray();
                    Alcohol alcohol = new Alcohol()
                    {
                        Name = alcoholVM.Name,
                        Description = alcoholVM.Description,
                        Type = alcoholVM.Type,
                        Degree = alcoholVM.Degree,
                        Photo = fileBytes,
                        BackgroundColor = alcoholVM.BackgroundColor
                    };

                    _alcoholRepository.Add(alcohol);
                }
            }

            
            return View();
        }
    }
}

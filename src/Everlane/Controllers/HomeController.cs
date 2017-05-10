using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Everlane.Models;

namespace Everlane.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetTranslation(string newTranslation, string newLanguage)
        {
            var translationText = Translator.GetTranslation(newTranslation, newLanguage);
            //var regex = translationText.Replace("/[^a-zA-Z0-9]/g", "");
            return Json(translationText);
        }
    }
}

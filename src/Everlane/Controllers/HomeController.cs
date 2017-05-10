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
        public IActionResult ReturnTranslation(string languageInput, string textInput)
        {
            var newTranslator = new Translator();
            newTranslator.Language = languageInput;
            newTranslator.Translation = textInput;

            var translationText = newTranslator.GetTranslation();
            //var regex = translationText.Replace("/[^a-zA-Z0-9]/g", "");
            return Json(translationText);
        }
    }
}

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

        public IActionResult ReturnTranslation()
        {
            var text = "hello you";
            var lang = "de";
            var translationText = Translator.GetTranslation(text, lang);
            //var regex = translationText.Replace("/[^a-zA-Z0-9]/g", "");
            return Json(translationText);
        }
    }
}

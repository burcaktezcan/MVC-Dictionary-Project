using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcDictionary.Helpers;
using MvcDictionary.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MvcDictionary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IRepositoryWord _wordRepository;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _wordRepository = Repositoryfactory.CreateRepo("WORD");    
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Word> liste = _wordRepository.List();
            return View(liste);
        }

        public IActionResult CreateWord(int? id)
        {
            Word model = new Word();
            if (id.HasValue && id > 0)
            {
                List<Word> word = _wordRepository.List();
                model = word.First(c => c.Id == id);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateWord (Word word)
        {
            _wordRepository.Add(word);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _wordRepository.Delete(id);
            return RedirectToAction("Index");  
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

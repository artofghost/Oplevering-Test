using DndNotes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Logic;

namespace DndNotes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private User _user = new User();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Character()
        {
            
            List<CharacterModel> characterModels = new List<CharacterModel>();
            foreach (var character in _user.GetAllCharacters())
            {
                characterModels.Add(new CharacterModel(character));
            }
            return View(characterModels);
        }

        public IActionResult Category()
        {
            CategoryCollection categoryCollection = new CategoryCollection();
            List<CategoryModel> categoryModels = new List<CategoryModel>();
            foreach (var category in categoryCollection.categories)
            {
                categoryModels.Add(new CategoryModel(category));
            }
            return View(categoryModels);
        }
        public IActionResult Notes()
        {
            
            
            List<NotesModel> notesModels = new List<NotesModel>();
            foreach (var notes in _user.GetAllNotes())
            {
                notesModels.Add(new NotesModel(notes));
            }
            return View(notesModels);
        }
        
        public IActionResult NoteSubmit()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult NoteSubmit(NotesModel notesModel)
        {
            Note note = new()
            {
                Name = notesModel.Name,
                Text = notesModel.Text
            };
            return RedirectToAction("Notes");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

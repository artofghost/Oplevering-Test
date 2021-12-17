using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using DndNotes.Models;

namespace DndNotes.Controllers
{
    public class CharacterController : Controller
    {
        private User _user = new User();

        // GET: CharacterController
        public ActionResult Index()
        {
            List<CharacterModel> characterModels = new List<CharacterModel>();
            foreach (var characters in _user.GetAllCharacters())
            {
                characterModels.Add(new CharacterModel(characters));
            }
            return View(characterModels);           
        }

        // GET: CharacterController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CharacterController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CharacterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CharacterModel collection)
        {
            try
            {
                Character character = new Character();
                character.Name = collection.Name;
                character.Id = collection.Id;
                character.Icon = collection.Icon;
                character.Colour = collection.Colour;
                character.Class = collection.Class;
                character.Race = collection.Race;
                _user.CreateCharacter(character);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CharacterController/Edit/5
        public ActionResult Edit(int id)
        {
            Character character = _user.GetCharacet(id);

            CharacterModel characterModel = new CharacterModel(character);

            return View(characterModel);
        }

        // POST: CharacterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CharacterModel collection)
        {
            try
            {
                Character character = new Character();
                character.Name = collection.Name;
                character.Id = collection.Id;
                character.Icon = collection.Icon;
                character.Colour = collection.Colour;
                character.Class = collection.Class;
                character.Race = collection.Race;
                character.UpdateCharacter();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CharacterController/Delete/5
        public ActionResult Delete(int id)
        {
            Character character = _user.GetCharacet(id);

            CharacterModel characterModel = new CharacterModel(character);

            return View(characterModel);
        }

        // POST: CharacterController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CharacterModel collection)
        {
            try
            {
                Character character = new Character();
                character.Id = collection.Id;
                _user.DeleteCharacter(character);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

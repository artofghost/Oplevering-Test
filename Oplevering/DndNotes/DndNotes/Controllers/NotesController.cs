using DndNotes.Models;
using Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DndNotes.Controllers
{
    public class NotesController : Controller
    {
        private User _user = new User();

        // GET: NotesController
        public ActionResult Index()
        {
            List<NotesModel> notesModels = new List<NotesModel>();
            foreach (var notes in _user.GetAllNotes())
            {
                notesModels.Add(new NotesModel(notes));
            }
            return View(notesModels);
        }

        // GET: NotesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NotesController/Create
        public ActionResult Create()
        {
           

            

            return View();
            
        }

        // POST: NotesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NotesModel collection)
        {
            try
            {
                Note note = new Note();
                note.Id = collection.Id;
                note.Name = collection.Name;
                note.Text = collection.Text;
                _user.CreateNote(note);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NotesController/Edit/5
        public ActionResult Edit(int id)
        {
            
            Note note = _user.GetNote(id);

            NotesModel notesModel = new NotesModel(note);
          
            return View(notesModel);
        }

        // POST: NotesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, NotesModel collection)
        {

            try
            {
                Note note = new Note();
                note.Id = collection.Id;
                note.Name = collection.Name;
                note.Text = collection.Text;
                note.UpdateNote();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NotesController/Delete/5
        public ActionResult Delete(int id)
        {
            Note note = _user.GetNote(id);

            NotesModel notesModel = new NotesModel(note);

            return View(notesModel);
        }

        // POST: NotesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, NotesModel collection)
        {
            try
            {
                Note note = new Note();
                note.Id = collection.Id;
                _user.DeleteNote(note);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

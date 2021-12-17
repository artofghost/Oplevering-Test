using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Factory;
using Interface;

namespace Logic
{
    public class NotesCollection
    {
        public List<Note> notes = new List<Note>();
        private INoteCollection note;
        
        public NotesCollection()
        {
            note = NotesFactory.GetNotesDal();
            foreach (var notesDto in note.GetAllNotes())
            {
                notes.Add(new Note(notesDto));
            }
        }
   

    }
}

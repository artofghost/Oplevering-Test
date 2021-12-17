using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class NotesCollection
    {
        public List<Notes> notes = new List<Notes>();
        NotesDAL notesDal = new NotesDAL();

        public NotesCollection()
        {
            foreach (var notesDto in notesDal.GetAllNotes())
            {
                notes.Add(new Notes(notesDto));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Interface
{
    public interface INoteCollection
    {
        public List<NotesDto> GetAllNotes();
        public NotesDto GetNote(int Id);
        public void CreateNote(NotesDto notes, int UserId);
        public void DeleteNote(NotesDto notesDto);

    }
}

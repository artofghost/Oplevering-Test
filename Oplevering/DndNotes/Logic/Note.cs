using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface;
using Factory;
namespace Logic
{
    public class Note
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public string Text { get; set; }

        public Note(NotesDto notesDto)
        {
            Name = notesDto.Name;
            Id = notesDto.Id;
            Text = notesDto.Text;
        }
        public void UpdateNote()
        {
            NotesDto notesDto = new NotesDto();

            notesDto.Name = Name;
            notesDto.Id = Id;
            notesDto.Text = Text;

            INote note = NotesFactory.GetUpdateNoteDal();
            note.UpdateNote(notesDto);          


        }
        public Note()
        {
            
        }
    }
}

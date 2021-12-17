using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;

namespace DndNotes.Models
{
    public class NotesModel
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public string Text { get; set; }

        public NotesModel(Note notes)
        {
            Name = notes.Name;
            Id = notes.Id;
            Text = notes.Text;

        }
        public NotesModel()
        {

        }
    }
}

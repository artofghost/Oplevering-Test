using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Notes
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public string Text { get; set; }

        public Notes(NotesDTO notesDto)
        {
            Name = notesDto.Name;
            Id = notesDto.Id;
            Text = notesDto.Text;
        }
    }
}

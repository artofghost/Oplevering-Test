using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Interface;


namespace Factory
{
    public static class NotesFactory
    {
        public static INoteCollection GetNotesDal()
        {
            return new NotesDal();
        }
        public static INote GetUpdateNoteDal()
        {
            return new NotesDal();
        }
        //public static INoteCollection CreateInoteCollection()
        //{
        //    return new NotesDal();
        //}

    }
}

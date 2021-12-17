using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;

namespace DndNotes.Models
{
    public class CategoryModel
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public string Icon { get; set; }
        public string Colour { get; set; }

        public CategoryModel(Category category)
        {
            Name = category.Name;
            Id = category.Id;
            Icon = category.Icon;
            Colour = category.Colour;
        }  
        public CategoryModel()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Logic;

namespace DndNotes.Models
{
    public class CharacterModel
    {
       
        public int Id { get; set; }
        
        public string Name { get; set; }
        
      
        public string Icon { get; set; }
        
        public string Colour { get; set; }
       
        public string Class { get; set; }
        
        public string Race { get; set; }

        public CharacterModel(Character character)
        {
            Name = character.Name;
            Id = character.Id;
            Icon = character.Icon;
            Colour = character.Colour;
            Class = character.Class;
            Race = character.Race;
        }
        public CharacterModel()
        {

        }
    }
}

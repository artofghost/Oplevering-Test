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
    public class Character
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public string Icon { get; set; }
        public string Colour { get; set; }
        public string Class { get; set; }
        public string Race { get; set; }

        public Character(CharacterDto characterDto)
        {
            Name = characterDto.Name;
            Id = characterDto.Id;
            Icon = characterDto.Icon;
            Colour = characterDto.Colour;
            Class = characterDto.Class;
            Race = characterDto.Race;
        }
        public Character() { }
        public void UpdateCharacter()
        {
            CharacterDto characterDto = new CharacterDto();
            characterDto.Name = Name;
            characterDto.Id = Id;
            characterDto.Icon = Icon;
            characterDto.Colour = Colour;
            characterDto.Class = Class;
            characterDto.Race = Race;

            ICharacters characters = CharacterFactory.GetUpdateCharacterDal();
            characters.UpdateCharacter(characterDto);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory;
using Interface;

namespace Logic
{
    public class CharacterCollection
    {
        public List<Character> characters = new List<Character>();
        
        private ICharacterCollection character;

        public CharacterCollection()
        {
            character = CharacterFactory.GetCharacterCollectionDal();

            foreach (var characterDto in character.GetAllCharacters())
            {
                characters.Add(new Character(characterDto));
            }
        }
    }
}

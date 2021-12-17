using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface ICharacterCollection
    {
        public List<CharacterDto> GetAllCharacters();
        public CharacterDto GetCharacter(int Id);
        public void CreateCharacter(CharacterDto characterDto, int UserId);
        public void DeleteCharacter(CharacterDto characterDto);


    }
}

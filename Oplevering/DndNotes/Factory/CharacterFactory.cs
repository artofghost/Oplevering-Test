using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Interface;

namespace Factory
{
    public static class CharacterFactory
    {
        public static ICharacterCollection GetCharacterCollectionDal()
        {
            return new CharacterDal();
        }
        public static ICharacters GetUpdateCharacterDal()
        {
            return new CharacterDal();
        }
    }
}

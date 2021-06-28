using Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public interface ICharacterRepo
    {
        bool SaveChanges();
        IEnumerable<Character> GetCharacter();
        Character GetCharacterById(int id);
        void CreateCharacter(Character newCharacter);
        void UpdateCharacter(Character updateCharacter);
        void DeleteCharacter(Character deleteCharacter);
    }
}

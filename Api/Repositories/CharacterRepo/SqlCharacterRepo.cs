using Api.Data;
using Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public class SqlCharacterRepo : ICharacterRepo
    {
        private readonly DisneyDBContext _context;

        public SqlCharacterRepo(DisneyDBContext context)
        {
            _context = context;
        }

        public void CreateCharacter(Character newCharacter)
        {
            if (newCharacter == null)
            {
                throw new ArgumentNullException(nameof(newCharacter));
            }

            _context.Characters.Add(newCharacter);
            _context.SaveChanges();
        }

        public void DeleteCharacter(Character deleteCharacter)
        {
            if (deleteCharacter == null)
            {
                throw new ArgumentNullException(nameof(deleteCharacter));
            }
            _context.Characters.Remove(deleteCharacter);
        }

        public IEnumerable<Character> GetCharacter()
        {
            return _context.Characters;
        }

        public Character GetCharacterById(int id)
        {
            return _context.Characters.FirstOrDefault(c => c.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCharacter(Character updateCharacter)
        {
           
        }
    }
}

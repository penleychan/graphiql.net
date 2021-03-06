﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarWars.Core.Data;
using StarWars.Core.Models;

namespace StarWars.Data.EntityFramework.Repositories
{
    public class CharacterRepository : BaseRepository<Character, int>, ICharacterRepository
    {
        public CharacterRepository()
        {
        }

        public CharacterRepository(StarWarsContext db) 
            : base(db)
        {
        }

        public async Task<ICollection<Character>> GetFriends(int id)
        {
            var character = await Get(id, "CharacterFriends.Friend");
            return character.CharacterFriends.Select(c => c.Friend).ToList();
        }

        public async Task<ICollection<Episode>> GetEpisodes(int id)
        {
            var character = await Get(id, "CharacterEpisodes.Episode");
            return character.CharacterEpisodes.Select(c => c.Episode).ToList();
        }
    }
}
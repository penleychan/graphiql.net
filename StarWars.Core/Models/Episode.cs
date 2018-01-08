using System.Collections.Generic;
using StarWars.Core.Data;

namespace StarWars.Core.Models
{
    public class Episode : IEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Character Hero { get; set; }
        public ICollection<CharacterEpisode> CharacterEpisodes { get; set; }
    }
}
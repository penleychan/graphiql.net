using StarWars.Core.Data;
using StarWars.Core.Models;

namespace StarWars.Data.EntityFramework.Repositories
{
    public class EpisodeRepository : BaseRepository<Episode, int>, IEpisodeRepository
    {
        public EpisodeRepository()
        {
        }

        public EpisodeRepository(StarWarsContext db)
            : base(db)
        {
        }
    }
}
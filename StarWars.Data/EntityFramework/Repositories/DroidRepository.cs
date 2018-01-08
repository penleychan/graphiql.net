using StarWars.Core.Data;
using StarWars.Core.Models;

namespace StarWars.Data.EntityFramework.Repositories
{
    public class DroidRepository : BaseRepository<Droid, int>, IDroidRepository
    {
        public DroidRepository()
        {
        }

        public DroidRepository(StarWarsContext db) 
            : base(db)
        {
        }
    }
}
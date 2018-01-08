using System.Data.Entity;
using StarWars.Core.Data;
using StarWars.Core.Models;

namespace StarWars.Data.EntityFramework.Repositories
{
    public class PlanetRepository : BaseRepository<Planet, int>, IPlanetRepository
    {
        public PlanetRepository()
        {
        }

        public PlanetRepository(DbContext db) : base(db)
        {
        }
    }
}
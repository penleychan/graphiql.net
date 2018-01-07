using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphiQl.Example.GraphQl
{
    public class StarWarsData
    {
        private readonly List<Droid> _droids = new List<Droid>();

        public StarWarsData()
        {
            _droids.Add(new Droid
            {
                Id = "1",
                Name = "R2-D2",
            });
            _droids.Add(new Droid
            {
                Id = "2",
                Name = "C-3PO",
            });
        }

        public Task<Droid> GetDroidByIdAsync(string id)
        {
            return Task.FromResult(_droids.FirstOrDefault(h => h.Id == id));
        }
    }
}
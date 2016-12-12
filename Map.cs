using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace benimKodlar
{
    public class Map
    {
        public Country[] allCountries;
        public Human[] allHumans;
        public Player player;

        public Map(int P, int N)
        {
            allHumans = new Human[P];
            allCountries = new Country[N*N];
        }

    }
}

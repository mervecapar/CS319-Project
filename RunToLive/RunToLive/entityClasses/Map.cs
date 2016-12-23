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
        private Player player;

        public Map(int P, int N)
        {
            allHumans = new Human[P];
            allCountries = new Country[N*N];
            player = new Player("ali", 10, Player.genderType.MAN);
        }

        public Player getPlayer()
        {
            return player;
        }

    }
}

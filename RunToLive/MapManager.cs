using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace benimKodlar
{
    public class MapManager
    {
        public Map gameMap;
        
        public MapManager(int P, int N)
        {
            gameMap = new Map(P,N);
        }

        public Map getMap()
        {
            return gameMap;
        }
        public void setMap(Map m)
        {
            gameMap = m;
        }

        //this method checks if wanted travelling country is near at at most 2 countyr far away. Because player
        //can not move more than 2 steps if he does not use power up. 
        // Player can move 2 step right,top,bottom,left and can move 1 step to diagonal
        public bool checkIfTravelCountryIsOkay(int countryID)
        {
            foreach (Country c1 in gameMap.allCountries)
            {
                if (c1.countryId == countryID)
                {
                    //check first neighbores
                    foreach (Country c2 in c1.neighbores)
                    {
                        if (c2.countryId == countryID)
                            return true;
                        else
                        {
                            //check neighbores of the neighbores
                            foreach (Country c3 in c2.neighbores)
                            {
                                if (c3.countryId == countryID)
                                    return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        //travel and if it is possible travel if not return false
        public bool makePlayerTravel(int countryID)
        {
            if (checkIfTravelCountryIsOkay(countryID))
            {
                foreach (Country c1 in gameMap.allCountries)
                {
                    if (c1.countryId == countryID)
                    {
                        gameMap.getPlayer().currentCountryId = c1.countryId;
                        c1.addHuman(gameMap.getPlayer());
                    }
                }
                return true;
            }
            else
                return false;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace benimKodlar
{
    class testsForEntityClasses
    {
        static void Main(string[] args)
        {
            World world = new World(50, 10, 5, 5, 5, 2, 30);
            int[] currentStatus = world.returnCurrentStatus();

            //printing if statistics are right or not in whole world
            Console.WriteLine("totalHealthy:" + currentStatus[0]);
            Console.WriteLine("totalInfected:" + currentStatus[1]);
            Console.WriteLine("totalSicked:" + currentStatus[2]);
            Console.WriteLine("totalDied:" + currentStatus[3]);
            Console.WriteLine("totalSuperHuman:" + currentStatus[4]);
            Console.WriteLine("totaldOCTOR:" + currentStatus[6]);
            Console.WriteLine("day:" + currentStatus[5]);

            //print neighbores of some countries
            Console.WriteLine("neighbore country of 0");
            foreach (Country n in world.mapManager.gameMap.allCountries[0].neighbores)
                Console.WriteLine("countryIDNeigboe:" + n.countryId);
            Console.WriteLine("neighbore country of 12");
            foreach (Country n in world.mapManager.gameMap.allCountries[12].neighbores)
                Console.WriteLine("countryIDNeigboe:" + n.countryId);
            Console.WriteLine("neighbore country of 14");
            foreach (Country n in world.mapManager.gameMap.allCountries[14].neighbores)
                Console.WriteLine("countryIDNeigboe:" + n.countryId);

            //print counry id of people
            foreach (Human h in world.mapManager.gameMap.allHumans)
                Console.WriteLine("countryID:" + h.currentCountryId);


            //print some sample travel days
            foreach (Human h in world.mapManager.gameMap.allHumans)
                Console.WriteLine("travelday:" + h.travelDaysLater);

            //pass 2 day
            Console.WriteLine("after pass 16 day:");
            world.passADay();
            world.passADay();
            world.passADay();
            world.passADay();
            world.passADay();
            world.passADay();
            world.passADay();
            world.passADay();
            world.passADay();
            world.passADay();
            world.passADay();
            world.passADay();
            world.passADay();
            world.passADay();
            world.passADay();
            world.passADay();
            int[] currentStatus2 = world.returnCurrentStatus();
            //printing if statistics are right or not in whole world
            Console.WriteLine("totalHealthy:" + currentStatus2[0]);
            Console.WriteLine("totalInfected:" + currentStatus2[1]);
            Console.WriteLine("totalSicked:" + currentStatus2[2]);
            Console.WriteLine("totalDied:" + currentStatus2[3]);
            Console.WriteLine("totalSuperHuman:" + currentStatus2[4]);
            Console.WriteLine("totaldOCTOR:" + currentStatus[6]);
            Console.WriteLine("day:" + currentStatus2[5]);
 
            Console.ReadLine();




        }
        

    }
}

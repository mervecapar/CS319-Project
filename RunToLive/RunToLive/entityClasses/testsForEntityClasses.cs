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
            Game g = new Game(0);
            int[] stats;
            stats= g.world.returnCurrentStatus();
            Console.WriteLine("totalHealthy:" + stats[0]);
            Console.WriteLine("totalInfected:"+ stats[1]);
            Console.WriteLine("totalSicked:"+ stats[2]);
            Console.WriteLine("totalDied:"+ stats[3]);
            Console.WriteLine("totalSuperHuman:"+ stats[4]);
            Console.WriteLine("day:"+ stats[5]);
            Console.WriteLine("totalNumberOfDoctor:"+ stats[6]);

            Console.WriteLine("day:" + g.world.day);
            Console.WriteLine("id:" + g.world.mapManager.gameMap.player.currentCountryId);
            g.passTurn(10);

            Console.WriteLine("day:" + g.world.day);
            Console.WriteLine("id:" + g.world.mapManager.gameMap.player.currentCountryId);
            stats = g.world.returnCurrentStatus();
            Console.WriteLine("totalHealthy:" + stats[0]);
            Console.WriteLine("totalInfected:" + stats[1]);
            Console.WriteLine("totalSicked:" + stats[2]);
            Console.WriteLine("totalDied:" + stats[3]);
            Console.WriteLine("totalSuperHuman:" + stats[4]);
            Console.WriteLine("day:" + stats[5]);
            Console.WriteLine("totalNumberOfDoctor:" + stats[6]);

            Console.Read();

        }
        

    }
}

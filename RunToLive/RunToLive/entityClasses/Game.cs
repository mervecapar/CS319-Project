using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace benimKodlar
{
    class Game
    {
        public World world;
        private GameInitializer gameInitializer;
        private bool isFinished;
        private int[] settings;
        private int totalCountryCount = 0;
        private int diffuculty;
        public Game(int difficulty)
        {
            gameInitializer = new GameInitializer();
            this.settings = new int[7];
            this.diffuculty = difficulty;
            //				for (int i = 0; i < 7; i++)
            //					this.settings [i] = 0;
            isFinished = false;
            this.createNewGame();

        }
        

        private void createNewGame()
        {
            this.settings = this.gameInitializer.getSettings(diffuculty);
            world = new World(settings[0], settings[1], settings[2], settings[3], settings[4], settings[5], settings[6]);
        }

        public void finishGame()
        {
            //TODO
            Console.WriteLine("Game Finished");
        }

        public bool checkIsGameFinished()
        {
            int[] status = world.returnCurrentStatus();
            if (status[1] == this.settings[0]) //Dead count == all human count
                isFinished = true;
            if (world.getMap().getPlayer().isDied) //Player is dead
                isFinished = true;
            if (status[0] == this.settings[0]) //Healthy count == all human count
                isFinished = true;

            return isFinished;


        }

        public int[,] giveStatisticsAllWorld() //int[countryID][statusNo]
        {
            int[,] tempArray = new int[totalCountryCount, 6];
            for (int i = 0; i < totalCountryCount; i++)
                for (int j = 0; j < 6; j++)
                    tempArray[i, j] = giveStatisticsACountry(i)[j];



            return tempArray;

        }


        //Returns an integer array
        //index 0 -> number of died 
        //index 1 -> number of doctor
        //index 2 -> number of infected
        //index 3 -> number of people
        //index 4 -> number of sicked
        //index 5 -> number of super human

        public int[] giveStatisticsACountry(int countryID)
        {
            int[] statistics = new int[6];
            statistics[0] = world.getMap().allCountries[countryID].numberOfDied;
            statistics[1] = world.getMap().allCountries[countryID].numberOfDoctor;
            statistics[2] = world.getMap().allCountries[countryID].numberOfInfected;
            statistics[3] = world.getMap().allCountries[countryID].numberOfPeople;
            statistics[4] = world.getMap().allCountries[countryID].numberOfSicked;
            statistics[5] = world.getMap().allCountries[countryID].numberOfSuperHuman;
            return statistics;
        }

        public void passTurn(int countryId, bool use2CountryPower)
        {
            //TODO
            if (checkIsGameFinished())
                finishGame();
            else
            {
                if (movePlayer(countryId, use2CountryPower))
                    world.passADay();
                else
                Console.WriteLine("gidemez karşim");
            }

        }

        private bool movePlayer(int countryId,bool use2CountryPower)
        {
            if (world.getMap().getPlayer().travelToCountry(ref world.getMap().allCountries, countryId, use2CountryPower))
            {
                world.getMap().allCountries[world.getMap().getPlayer().currentCountryId].removeHuman(world.getMap().getPlayer());
                world.getMap().allCountries[countryId].addHuman(world.getMap().getPlayer());
                world.getMap().getPlayer().currentCountryId = countryId;
                return true;
            }
            else
                return false;
            
        }

        public bool useCheckHimselfPower()
        {
            return world.getMap().getPlayer().useCheckHimselfPower();
        }

        public void useBeHealthyPower()
        {
            world.getMap().getPlayer().useBeHealthyPower();
        }

    }
}

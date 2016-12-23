/*
Contributors: Mehmet Nuri, Selin, Ege

*/
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
        private String finishMessage;
        public  int[] settings;
        private int totalCountryCount = 0;
        private int diffuculty;
        public Game(int difficulty)
        {
            gameInitializer = new GameInitializer();
            this.settings = new int[7];
            this.diffuculty = difficulty;
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
            System.Windows.MessageBox.Show(finishMessage);
        }

        public bool checkIsGameFinished()
        {
            int[] status = world.returnCurrentStatus();
            if (status[3] == this.settings[0]) //Dead count == all human count
            {
                isFinished = true;
                finishMessage = "All people in the owrld are dead!";
            }
            if (world.getMap().getPlayer().isDied) //Player is dead
            {
                isFinished = true;
                finishMessage = "Player is dead!";
            }
            if (status[1] + status[2] == 0)  //totalInfected + totalSıcked == 0
            {
                isFinished = true;
                finishMessage = "Virus can not no longer spread. People have gained immune.!";
            }
             
            return isFinished;
        }

        public int[] giveStatisticsAllWorld() //int[countryID][statusNo]
        {
            return world.returnCurrentStatus();
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

        public bool passTurn(int countryId, bool use2CountryPower)
        {
            //TODO
            if (checkIsGameFinished())
            {
                finishGame();
                return false;
                //new statistic window will be opened 
            }
            else
            {
                if (movePlayer(countryId, use2CountryPower))
                    world.passADay();
                else
                {
                    if(world.getMap().getPlayer().notTravelDay > 0)
                        System.Windows.MessageBox.Show("You can not stay same country any more !");
                    else
                        System.Windows.MessageBox.Show("Travel not possible.");
                }
                    
                return true;
            }
        }

        private bool movePlayer(int countryId,bool use2CountryPower)
        {
            int playerBeforeCountry = world.getMap().getPlayer().currentCountryId;
            if (playerBeforeCountry == countryId)
                world.mapManager.gameMap.player.notTravelDay++;
            else
                world.mapManager.gameMap.player.notTravelDay = 0;

            
            if (world.getMap().getPlayer().travelToCountry(ref world.getMap().allCountries, countryId, use2CountryPower))
            {
                
                world.mapManager.gameMap.allCountries[world.getMap().getPlayer().currentCountryId].removeHuman(world.getMap().getPlayer());
                world.mapManager.gameMap.allCountries[countryId].addHuman(world.getMap().getPlayer());
                world.mapManager.gameMap.player.currentCountryId = countryId;

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

        public int giveMeCountryNumber()
        {
            return settings[2];
        }

        public int giveMeTotalPeopleNumber()
        {
            return settings[0];
        }

        public int giveInfectedProbOfPlayer()
        {
            return world.giveMePlayerInfectedProb(world.getMap().getPlayer());
        }

        public String giveNews()
        {
            int[] statistics = world.returnCurrentStatus();
            int totalHealthy = 0;
            int totalInfected = 0;
            int totalSicked = 0;
            int totalDied = 0;
            int totalSuperHuman = 0;
            int totalNumberOfDoctor = 0;
            int day = 0;
            totalHealthy = statistics[0];
            totalInfected = statistics[1];
            totalSicked = statistics[2];
            totalDied = statistics[3];
            totalSuperHuman = statistics[4];
            day = statistics[5];
            totalNumberOfDoctor = statistics[6];

            if (day == 0 || day == 1)
                return "The World is under affect of a virus";
            else if (totalDied > 0)
                return "First human has been died by virus";
            else if ((totalInfected * 100) / totalHealthy > 25)
                return "The World is getting infected day by day";
            else if ((totalSicked * 100) / totalHealthy > 25)
                return "Sickness are start to seen all over the world";
            else if ((totalInfected + totalSicked + totalDied) < totalHealthy && totalNumberOfDoctor > 0)
                return "Vaccinating process continuing";
            else if ((totalInfected * 100) / totalHealthy < 25 && (totalSicked * 100) / totalHealthy < 25)
                return "Virus start to lose its effect";
            else
                return "Whole world is trying to survive from virus";

        }
    }
}

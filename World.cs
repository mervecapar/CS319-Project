using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace benimKodlar
{
    public class World
    {
        public int day;
        public int vaccinateDay;
        public int airPossibility;
        public MapManager mapManager;

        //Function to get random number
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();

        //world takes input parameters which are mapManager.gameMap.allHumans,infected percentage etc. 
        // P : total number of people in the world
        // X : % percentage of infected  people in the society 
        // N : 5x5 or 6x6 etc. number of grids country
        // S : % percentage of super human people in the society 
        // D : % percentage of super doctors people in the society 
        // V : A doctor can vaccinate at most V people in each day
        // A : When a person decides to travel, with A% probability, she chooses to use air travel to fly to a random country
        public World(int P, int X, int N, int S, int D, int V, int A)
        {
            day = 0;
            vaccinateDay = V;
            airPossibility = A;
            mapManager = new MapManager(P, N);
            //converting percentage from integer, because X is percentage for example we need to find its integer values in population
            int xNumber = (int)(P * (X / 100.0));
            int sNumber = (int)(P * (S / 100.0));
            int dNumber = (int)(P * (D / 100.0));

            //creating all humans in the map
            for (int a = 0; a < P; a++)
                mapManager.gameMap.allHumans[a] = new Human();
            

            for (int i = 0; i < xNumber; i++)//infected
                mapManager.gameMap.allHumans[i].isInfected = true;

            for (int p = xNumber; p < xNumber + sNumber; p++)//super
                mapManager.gameMap.allHumans[p].isSuperHuman = true;

            for (int t = xNumber + sNumber; t < xNumber + sNumber + dNumber; t++)//doctor
                mapManager.gameMap.allHumans[t].isDoctor = true;

            //give country id to countries 
            for (int b = 0; b < N * N; b++)
            {
                mapManager.gameMap.allCountries[b] = new Country();
                mapManager.gameMap.allCountries[b].setId(b);
            }

            for (int c = 0; c < N * N; c++) //setting up neighbores
                mapManager.gameMap.allCountries[c].createNeighbores(N, mapManager.gameMap.allCountries);

            spreadThePeople(); //people are distrubited and travel days are determined, now world is ready to pass a day
        }

        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }

        //spread all the people all over the world randomly 
        public void spreadThePeople()
        {
            int whichCountry;
            foreach(Human h in mapManager.gameMap.allHumans)
            {
                whichCountry = RandomNumber(0, mapManager.gameMap.allCountries.Length);
                mapManager.gameMap.allCountries[whichCountry].addHuman(h);
                h.currentCountryId = mapManager.gameMap.allCountries[whichCountry].countryId;
                h.determineTravelDay();
            }
 
        }

        //scan all over the world and if some people needs to have to determine travel day it controls it and determines travel day
        public void scanPeopleDetermineTravelDay()
        {
            for (int i = 0; i < mapManager.gameMap.allHumans.Length; i++)
                if (mapManager.gameMap.allHumans[i].travelDaysLater == 0)
                    mapManager.gameMap.allHumans[i].determineTravelDay();
        }

        public bool giveMePossibility(int percent)
        {
            bool[] list = new bool[100];
            for (int i = 0; i < 100; i++)
                if (i < percent)
                    list[i] = true;
                else
                    list[i] = false;

            int a = RandomNumber(0,100);
            return list[a];
        }

        //after travelling another country if there are sick or infected people, a human can get infected by %40 chance
        //so this method applies this rule
        public void changeStatusAfterAllTravels()
        {
            for (int i = 0; i < mapManager.gameMap.allHumans.Length; i++)
            {
                if (mapManager.gameMap.allCountries[mapManager.gameMap.allHumans[i].currentCountryId].numberOfInfected > 0 || mapManager.gameMap.allCountries[mapManager.gameMap.allHumans[i].currentCountryId].numberOfSicked > 0)
                    if (giveMePossibility(40)) //%40 get infected
                    {
                        if (!mapManager.gameMap.allHumans[i].isInfected && !mapManager.gameMap.allHumans[i].isSick && !mapManager.gameMap.allHumans[i].isDied && !mapManager.gameMap.allHumans[i].isSuperHuman)
                        {
                            mapManager.gameMap.allHumans[i].isInfected = true;
                            mapManager.gameMap.allCountries[mapManager.gameMap.allHumans[i].currentCountryId].numberOfInfected++;
                        }
                    }
            }
        }

        //it returns some datas about whole world 
        public int[] returnCurrentStatus()
        {
            int[] statistics = new int[7];
            int healthy = 0;
            int totalHealthy = 0;
            int totalInfected = 0;
            int totalSicked = 0;
            int totalDied = 0;
            int totalSuperHuman = 0;
            int totalNumberOfDoctor = 0;
            foreach(Country c in  mapManager.gameMap.allCountries)
            {
                totalInfected += c.numberOfInfected;
                totalSicked += c.numberOfSicked;
                totalDied += c.numberOfDied;
                totalSuperHuman += c.numberOfSuperHuman;
                totalNumberOfDoctor += c.numberOfDoctor;
                healthy = c.numberOfPeople - c.numberOfInfected - c.numberOfSicked - c.numberOfDied - c.numberOfSuperHuman - c.numberOfDoctor;
                totalHealthy += healthy;
            }
            statistics[0] = totalHealthy;
            statistics[1] = totalInfected;
            statistics[2] = totalSicked;
            statistics[3] = totalDied;
            statistics[4] = totalSuperHuman;
            statistics[5] = this.day;
            statistics[6] = totalNumberOfDoctor;
            return statistics;
        }

        public void passADay()
        {
            day++;
            foreach (Human h in mapManager.gameMap.allHumans) //travel people if necessary
            {
                if (h.isInfected || h.isSick) //if she is infected, day after she is infected increasing
                    h.daysPassedAfterInfected++;

                h.travelDaysLater--;
                h.travelIfNecessary(ref mapManager.gameMap.allCountries, airPossibility);
                h.checkThePersonsInfection(ref mapManager.gameMap.allCountries);
                changeStatusAfterAllTravels();
                h.vaacinatePeople(ref mapManager.gameMap.allHumans, vaccinateDay);
            }
        }

    }
}

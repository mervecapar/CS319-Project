using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace benimKodlar
{
    public class Human
    {
        public bool isInfected;
        public bool isSick;
        public bool isDied;
        public bool isSuperHuman;
        public bool isDoctor;
        public int travelDaysLater;
        public int currentCountryId;
        public int daysPassedAfterInfected;

        //Function to get random number
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public Human()
        {
            daysPassedAfterInfected = 0;
            travelDaysLater = 0;
            currentCountryId = 0;
            isInfected = false;
            isSick = false;
            isDied = false;
            isSuperHuman = false;
            isDoctor = false;
        }


        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }

        //humans travels within 5 days after they have travelled. So this method determines how many days later
        //should human travel just after travelling.
        public void determineTravelDay()
        {
            travelDaysLater = RandomNumber(1, 6);
        }

        //give true or false with given percent
        public bool giveMePossibility(int percent)
        {
            bool[] list = new bool[100];

            for (int i = 0; i < 100; i++)
                if (i < percent)
                    list[i] = true;
                else
                    list[i] = false;
            Random rand = new Random();
            int a = rand.Next(0,99);
            return list[a];
        }
        //check if travel is needen I mean if travel days has come, this human should travel and this method 
        //realizes the travel.
        public void travelIfNecessary(ref Country[] allCountries, int airPossibility)
        {
            if (travelDaysLater == 0 && !isDied)
            {
                List<Country> availableCountries = new List<Country>();
                if (giveMePossibility(airPossibility))//air traffic
                {
                    for (int o = 0; o < allCountries.Length; o++)
                        if (allCountries[o].numberOfInfected == 0 || allCountries[o].numberOfDied == 0)
                            availableCountries.Add(allCountries[o]);
                }
                else//not air traffic
                {
                    for (int i = 0; i < allCountries[currentCountryId].neighbores.Length; i++)
                        if (allCountries[currentCountryId].neighbores[i].numberOfInfected == 0 || allCountries[currentCountryId].neighbores[i].numberOfDied == 0)
                            availableCountries.Add(allCountries[currentCountryId].neighbores[i]);
                }

                if (availableCountries.Count > 0)
                {
                    int a = RandomNumber(0,availableCountries.Count);
                    currentCountryId = availableCountries[a].countryId;
                    availableCountries[a].addHuman(this);
                    allCountries[currentCountryId].removeHuman(this);
                }
                determineTravelDay(); //determine new travel day
            
            }
        }

        public void checkThePersonsInfection(ref Country[] allCountries)
        {
            if (daysPassedAfterInfected == 6 && !isDied)
            {
                isInfected = false;
                isSick = true;
                allCountries[currentCountryId].numberOfInfected--;
                allCountries[currentCountryId].numberOfSicked++;
            }
            else if (daysPassedAfterInfected == 14 && !isDied)
            {
                if (giveMePossibility(25))
                {
                    isSick = false;
                    isDied = true;
                    allCountries[currentCountryId].numberOfSicked--;
                    allCountries[currentCountryId].numberOfDied++;
                }
            }
            else if (daysPassedAfterInfected == 16 && !isDied)
            {
                isSick = false;
                isInfected = true;
                allCountries[currentCountryId].numberOfInfected++;
                allCountries[currentCountryId].numberOfSicked--;
            }
            else if (daysPassedAfterInfected == 18 && !isDied)
            {
                isInfected = false;
                allCountries[currentCountryId].numberOfInfected--;
                daysPassedAfterInfected = 0;
            }
        }

        public void vaacinatePeople(ref Human[] populationList, int vaccinateNumber)
        {
            if (isDoctor)
            {
                int left = vaccinateNumber;
                for (int i = 0; i < populationList.Length; i++)
                {
                    if (left == 0)
                        break;
                    if (populationList[i].currentCountryId == currentCountryId && !populationList[i].isInfected && !populationList[i].isSick && !populationList[i].isDied && !populationList[i].isSuperHuman)
                    {
                        populationList[i].isSuperHuman = true;
                        vaccinateNumber--;
                    }
                }
            }
        }
    }
}

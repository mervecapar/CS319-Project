/*
Contributors: Mehmet Nuri

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace benimKodlar
{   
    public class Country
    {
        public int countryId;
        public int numberOfPeople;
        public int numberOfInfected;
        public int numberOfSicked;
        public int numberOfDied;
        public int numberOfSuperHuman;
        public int numberOfDoctor;
        public Country[] neighbores;
        public string newColor;

        public Country()
        {
            numberOfPeople = 0;
            numberOfInfected = 0;
            numberOfSicked = 0;
            numberOfDied = 0;
            numberOfSuperHuman = 0;
            numberOfDoctor = 0;
            newColor = "Green";
        }
        
        public void addHuman(Human h)
        {
            numberOfPeople++;
            if (h.isInfected)
                numberOfInfected++;
            if (h.isDied)
                numberOfDied++;
            if (h.isDoctor)
                numberOfDoctor++;
            if (h.isSick)
                numberOfSicked++;
            if (h.isSuperHuman)
                numberOfSuperHuman++;
        }

        public void removeHuman(Human h)
        {
            numberOfPeople--;
            if (h.isInfected)
                numberOfInfected--;
            if (h.isDied)
                numberOfDied--;
            if (h.isDoctor)
                numberOfDoctor--;
            if (h.isSick)
                numberOfSicked--;
            if (h.isSuperHuman)
                numberOfSuperHuman--;
        }

       

        public void setId(int id)
        {
            countryId = id;
        }

        public void createNeighbores(int N, Country[] allCountries)
        {
            if (countryId >= 0 && countryId < N)
            {
                if (countryId == 0)
                {
                    neighbores = new Country[4];
                    neighbores[0] = allCountries[N];
                    neighbores[1] = allCountries[1];
                    neighbores[2] = allCountries[N * (N - 1)];
                    neighbores[3] = allCountries[(N - 1)];
                }
                else if (countryId == N - 1)
                {
                    neighbores = new Country[4];
                    neighbores[0] = allCountries[N - 2];
                    neighbores[1] = allCountries[2 * N - 1];
                    neighbores[2] = allCountries[N * N - 1];
                    neighbores[3] = allCountries[0];
                }
                else
                {
                    neighbores = new Country[4];
                    neighbores[0] = allCountries[countryId - 1];
                    neighbores[1] = allCountries[countryId + 1];
                    neighbores[2] = allCountries[countryId + N];
                    neighbores[3] = allCountries[countryId + (N * (N - 1))];
                }
            }
            else if (countryId >= ((N * N) - N))
            {
                if (countryId == (N * N) - N)
                {
                    neighbores = new Country[4];
                    neighbores[0] = allCountries[countryId - N];
                    neighbores[1] = allCountries[countryId + 1];
                    neighbores[2] = allCountries[0];
                    neighbores[3] = allCountries[countryId + (N - 1)];
                }
                else if (countryId == (N * N) - 1)
                {
                    neighbores = new Country[4];
                    neighbores[0] = allCountries[countryId - N];
                    neighbores[1] = allCountries[countryId - 1];
                    neighbores[2] = allCountries[N - 1];
                    neighbores[3] = allCountries[countryId - (N - 1)];
                }
                else
                {
                    neighbores = new Country[4];
                    neighbores[0] = allCountries[countryId - 1];
                    neighbores[1] = allCountries[countryId + 1];
                    neighbores[2] = allCountries[countryId - N];
                    neighbores[3] = allCountries[countryId - (N * (N - 1))];
                }
            }
            else if (countryId % N == 0)
            {
                neighbores = new Country[4];
                neighbores[0] = allCountries[countryId + N];
                neighbores[1] = allCountries[countryId + 1];
                neighbores[2] = allCountries[countryId - N];
                neighbores[3] = allCountries[countryId + (N - 1)];
            }
            else if ((countryId + 1) % N == 0)
            {
                neighbores = new Country[4];
                neighbores[0] = allCountries[countryId - 1];
                neighbores[1] = allCountries[countryId + N];
                neighbores[2] = allCountries[countryId - N];
                neighbores[3] = allCountries[countryId - (N - 1)];
            }
            else
            {
                neighbores = new Country[4];
                neighbores[0] = allCountries[countryId - 1];
                neighbores[1] = allCountries[countryId + 1];
                neighbores[2] = allCountries[countryId - N];
                neighbores[3] = allCountries[countryId + N];
            }
        }


    }   
}

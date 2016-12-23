/*
Contributors: Mehmet Nuri, Ege

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace benimKodlar
{
    public class Player : Human
    {
        public enum genderType{
        MAN,
        WOMAN };

        String name;
        genderType gender;
        public int notTravelDay;
        //WPF.PlayerWinFormUserControl movementHanler;

        public Player(String name, int startCountryID, genderType g)
        {
            this.name = name;
            this.gender = g;
            currentCountryId = startCountryID;
            notTravelDay = 0;
        }

        public bool useCheckHimselfPower()
        {
            if (this.isInfected || this.isSick || this.isDied)
                return true;
            else
                return false;
        }

        public bool useBeHealthyPower()
        {
            if (this.isInfected || this.isSick)
            {
                this.isInfected = false;
                this.isSick = false;
                return true;
            }
            else
                return false;
        }


        public bool travelToCountry(ref Country[] allCountries, int wantedCountryId, bool use2CountryPower)
        {
            if (notTravelDay < 5)
            {
                bool include = false;
                if (!use2CountryPower)
                {
                    if (wantedCountryId == currentCountryId)
                        return true;
                    foreach (Country c in allCountries[currentCountryId].neighbores)
                    {
                        if (c.countryId == wantedCountryId)
                        {
                            include = true;
                            break;
                        }
                    }
                }
                else
                {
                    if (wantedCountryId == currentCountryId)
                        return true;
                    foreach (Country c in allCountries[currentCountryId].neighbores)
                    {
                        if (c.countryId == wantedCountryId)
                        {
                            include = true;
                            break;
                        }
                        foreach (Country c2 in c.neighbores)
                            if (c2.countryId == wantedCountryId)
                            {
                                include = true;
                                break;
                            }
                    }

                }
                return include;
            }
            else
                return false;
            

        }

    }
}

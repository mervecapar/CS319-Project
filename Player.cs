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
        public bool powerMove2Country;
        public bool powerBeHealthy;
        public bool powerCheckHimself;
        //WPF.PlayerWinFormUserControl movementHanler;

        public Player(String name, int startCountryID, genderType g)
        {
            this.name = name;
            this.gender = g;
            currentCountryId = startCountryID;
            powerMove2Country = false;
            powerBeHealthy = false;
            powerCheckHimself = false;
        }

        public bool useCheckHimselfPower()
        {
            if (this.isInfected || this.isSick || this.isDied)
                return true;
            else
                return false;
            powerCheckHimself = false;
        }

        public void useBeHealthyPower()
        {
            if (this.isInfected || this.isSick)
            {
                this.isInfected = false;
                this.isSick = false;
            }
            powerBeHealthy = false;
        }
    }
}

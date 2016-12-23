using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace benimKodlar
{
    class GameInitializer
    {
        private int[] settings;

        public GameInitializer()
        {
            settings = new int[7];
        }


        public int[] getSettings(int difficulty)
        {
            if (difficulty == 1)
            {
                this.settings[0] = 1600;
                this.settings[1] = 10;
                this.settings[2] = 8;
                this.settings[3] = 10;
                this.settings[4] = 10;
                this.settings[5] = 2;
                this.settings[6] = 25;
            }
            else if (difficulty == 2)
            {
                settings[0] = 576;
                settings[1] = 15;
                settings[2] = 6;
                settings[3] = 7;
                settings[4] = 7;
                settings[5] = 2;
                settings[6] = 15;
            }
            else {
                settings[0] = 875;
                settings[1] = 20;
                settings[2] = 5;
                settings[3] = 3;
                settings[4] = 5;
                settings[5] = 2;
                settings[6] = 7;
            }

            return settings;
        }
    }
}

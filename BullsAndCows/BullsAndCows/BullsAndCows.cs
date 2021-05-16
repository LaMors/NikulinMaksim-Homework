using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    public class BullsAndCows
    {
        public int Bulls { get; set; }

        public int Cows { get; set; }

        public bool Equals(BullsAndCows bullsAndCows)
        {
            if (this.Bulls == bullsAndCows.Bulls && this.Cows == bullsAndCows.Cows)
                return true;

            else
                return false;
        }


    }
}

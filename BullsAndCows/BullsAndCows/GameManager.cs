using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    public class GameManager
    {
        private Game game;

        public GameManager(Game game)
        {
            this.game = game;
        }

        public void Start()
        {
            var gameContinues = game.MakeMove();

            var counter = default(int);

            while (gameContinues)
            {
                counter++;

                gameContinues = game.MakeMove();
            }
        }
    }
}

using System;

namespace BullsAndCows
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameManager = new GameManager(new Game());

            gameManager.Start();

        }
    }
}

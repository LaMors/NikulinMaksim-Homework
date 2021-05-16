using System;

namespace BullsAndCows
{
    class Program
    {
        static void Main(string[] args)
        {
            //var game = new Game();

            //var p = Console.ReadLine();
            //var k = Console.ReadLine();
            //var t = game.GetQuantityBullsAndCows(p, k);
            //Console.WriteLine(t.Bulls);
            //Console.WriteLine(t.Cows);
            var gameManager = new GameManager(new Game());

            gameManager.Start();

        }
    }
}

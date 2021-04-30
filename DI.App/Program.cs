using DI.App.Services.PL;

namespace DI.App
{
    internal class Program
    {
        private static void Main()
        {
            // Inversion of Control
            // Complite
            var manager = new CommandManager();

            manager.Start();
        }
    }
}

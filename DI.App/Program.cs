using DI.App.Abstractions;
using DI.App.Services;
using DI.App.Services.DAL;
using DI.App.Services.PL;
using DI.App.Services.PL.Commands;
using System.Collections.Generic;

namespace DI.App
{
    internal class Program
    {
        private static void Main()
        {
            // Inversion of Control
            var addUsers = new AddUserCommand(new UserStore(new InDatabaseUserService()));
            var listUsers = new ListUsersCommand(new UserStore(new InDatabaseUserService()));

            var commands = new Dictionary<int, ICommand>();
            commands.Add(addUsers.Number, addUsers);
            commands.Add(listUsers.Number, listUsers);

            var commandManager = new CommandProcessor(commands);

            var manager = new CommandManager(commandManager);

            manager.Start();
        }
    }
}

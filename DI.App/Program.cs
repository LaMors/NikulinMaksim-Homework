using DI.App.Abstractions;
using DI.App.Models;
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
            var users = new Dictionary<int, IDbEntity>();
            users.Add(1, new User());
            users.Add(2, new User());
            var dataService = new InDatabaseUserService(new InMemoryDatabaseService(users));

            var userStore = new UserStore(dataService);
            var addUsers = new AddUserCommand(userStore);
            var listUsers = new ListUsersCommand(userStore);

            var commands = new Dictionary<int, ICommand>();
            commands.Add(addUsers.Number, addUsers);
            commands.Add(listUsers.Number, listUsers);

            var commandManager = new CommandProcessor(commands);

            var manager = new CommandManager(commandManager);

            manager.Start();
        }
    }
}

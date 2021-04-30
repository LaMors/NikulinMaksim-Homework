using System.Collections.Generic;
using System.Linq;
using DI.App.Abstractions;
using DI.App.Abstractions.BLL;

namespace DI.App.Services
{
    public class UserStore : IUserStore
    {
        private readonly IDatabaseService<IUser> dbService;

        public UserStore(IDatabaseService<IUser> databaseService)
        {
            dbService = databaseService;
        }

        public IEnumerable<IUser> Users => this.dbService.Read();

        public void AddUser(IUser user)
        {
            this.dbService.Write(user);
        }

        public IUser FindUser(string name)
        {
            return this.dbService.Read()
                .FirstOrDefault(user => user.Name == name);
        }

        public IUser FindUser(int id)
        {
            return this.dbService.Read()
                .FirstOrDefault(user => user.Id == id);
        }
    }
}
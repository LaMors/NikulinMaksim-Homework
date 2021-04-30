using DI.App.Abstractions;
using DI.App.Abstractions.BLL;
using DI.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.App.Services.DAL
{
    public class InDatabaseUserService : IDatabaseService<IUser, IDbEntity>
    {
        private readonly IDatabaseService<IDbEntity, IDbEntity> databaseService;

        public InDatabaseUserService(IDatabaseService<IDbEntity, IDbEntity> databaseService)
        {
            this.databaseService = databaseService;
        }

        public IEnumerable<IUser> Read()
        {
            var users = new List<IUser>();

            var entitys = databaseService.Read();

            foreach (var entity in entitys)
            {
                users.Add(entity.ToUser());
            }
            return users;
        }

        public void Write(params IDbEntity[] data)
        {
            databaseService.Write(data);
        }
    }
}

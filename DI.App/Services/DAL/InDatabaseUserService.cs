using DI.App.Abstractions;
using DI.App.Abstractions.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.App.Services.DAL
{
    public class InDatabaseUserService : IDatabaseService<IUser>
    {
        private readonly IDatabaseService<IDbEntity> databaseService;

        public IEnumerable<IUser> Read()
        {
            return (IEnumerable<IUser>)databaseService.Read();
        }

        public void Write(params IUser[] data)
        {
            databaseService.Write(data);
        }
    }
}

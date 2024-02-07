using Microsoft.EntityFrameworkCore;
using RbPharma.Domain.V1.Entities;
using RbPharma.Infrastructure.Contexts.V1;
using RbPharma.Infrastructure.GenericInterfaces.V1;
using RbPharma.Infrastructure.Users.V1.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbPharma.Infrastructure.Users.V1.Repositories
{
    public class UserRepository : GenericRepositorio<User>, IUserRepository
    {
        private readonly ContextSql _contextSql;

        public UserRepository(ContextSql contextSql) : base(contextSql)
        {
            _contextSql = contextSql;
        }

        public async Task DeleteUser(User user)
        {
            await base.Delete(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return base.GetAll();
        }

        public async Task<User> GetById(long id)
        {
            return await base.GetById(id);
        }

        public async Task InsertUser(User user)
        {
            await base.Insert(user);
        }

        public async Task UpdateUser(User user)
        {
            await base.Update(user);
        }
    }
}

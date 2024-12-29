using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IUserRepository UserRepository { get;}
        public IRoleRepository RoleRepository { get;}
        public IPermissionRepository PermissionRepository { get;}

        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}

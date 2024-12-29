using Identity.Domain.Repositories;
using Identity.Domain.Repositories.UnitOfWork;
using Identity.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IDbContextTransaction _transaction;
        public IUserRepository UserRepository { get; }
        public IRoleRepository RoleRepository { get; }
        public IPermissionRepository PermissionRepository { get; }

        public UnitOfWork(AppDbContext context, IUserRepository userRepository, IRoleRepository roleRepository,
            IPermissionRepository permissionRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            UserRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            RoleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
            PermissionRepository = permissionRepository ?? throw new ArgumentNullException(nameof(permissionRepository));
        }

        public async Task BeginTransactionAsync()
        {
            if (_transaction == null)
            {
                _transaction = await _context.Database.BeginTransactionAsync();
            }
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }

        }

        public async Task RollbackTransactionAsync()
        {
            if(_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose() 
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
    }
}

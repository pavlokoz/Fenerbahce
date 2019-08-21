using Fenerbahce.Models.EntityModels;
using Fenerbahce.UnitOfWork.Repository;
using System;

namespace Fenerbahce.UnitOfWork.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        IRepository<TestEntity> TestRepository { get; }
        IRepository<StudentEntity> StudentRepository { get; }
        IRepository<GroupEntity> GroupRepository { get; }
        IRepository<SportEntity> SportRepository { get; }
        IRepository<SchoolEntity> SchoolRepository { get; }
        IRepository<PaymentEntity> PaymentRepository { get; }
        IRepository<InstructorGroupEntity> InstructorGroupRepository { get; }
        IRepository<StudentParentEntity> StudentParentRepository { get; }
        IRepository<UserEntity> UserRepository { get; }
        IRepository<RoleEntity> RoleRepository { get; }
        IRepository<UserRoleEntity> UserRoleRepository { get; }
    }
}

using Fenerbahce.EF.Context;
using Fenerbahce.Models.EntityModels;
using Fenerbahce.UnitOfWork.Repository;

namespace Fenerbahce.UnitOfWork.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected FenerbahceContext Context { get; }

        public UnitOfWork(FenerbahceContext context)
        {
            Context = context;
        }

        private IRepository<TestEntity> testRepository;
        private IRepository<StudentEntity> studentRepository;
        private IRepository<GroupEntity> groupRepository;
        private IRepository<SportEntity> sportRepository;
        private IRepository<SchoolEntity> schoolRepository;
        private IRepository<PaymentEntity> paymentRepository;
        private IRepository<InstructorGroupEntity> instructorGroupRepository;
        private IRepository<StudentParentEntity> studentParentRepository;
        private IRepository<UserEntity> userRepository;
        private IRepository<RoleEntity> roleRepository;
        private IRepository<UserRoleEntity> userRoleRepository;
        private IRepository<CommentEntity> commentRepository;
        private IRepository<VisitorLogEntity> visitorLogRepository;

        public IRepository<VisitorLogEntity> VisitorLogRepository => visitorLogRepository ??
          (visitorLogRepository = new Repository<VisitorLogEntity>(Context));

        private IRepository<NewsEntity> newsRepository;


        public IRepository<TestEntity> TestRepository => testRepository ??
          (testRepository = new Repository<TestEntity>(Context));

        public IRepository<StudentEntity> StudentRepository => studentRepository ??
            (studentRepository = new Repository<StudentEntity>(Context));

        public IRepository<GroupEntity> GroupRepository => groupRepository ??
            (groupRepository = new Repository<GroupEntity>(Context));

        public IRepository<SportEntity> SportRepository => sportRepository ??
            (sportRepository = new Repository<SportEntity>(Context));

        public IRepository<SchoolEntity> SchoolRepository => schoolRepository ??
            (schoolRepository = new Repository<SchoolEntity>(Context));

        public IRepository<PaymentEntity> PaymentRepository => paymentRepository ??
            (paymentRepository = new Repository<PaymentEntity>(Context));

        public IRepository<InstructorGroupEntity> InstructorGroupRepository => instructorGroupRepository ??
            (instructorGroupRepository = new Repository<InstructorGroupEntity>(Context));

        public IRepository<StudentParentEntity> StudentParentRepository => studentParentRepository ??
           (studentParentRepository = new Repository<StudentParentEntity>(Context));

        public IRepository<UserEntity> UserRepository => userRepository ??
            (userRepository = new Repository<UserEntity>(Context));

        public IRepository<RoleEntity> RoleRepository => roleRepository ??
            (roleRepository = new Repository<RoleEntity>(Context));

        public IRepository<UserRoleEntity> UserRoleRepository => userRoleRepository ??
            (userRoleRepository = new Repository<UserRoleEntity>(Context));

        public IRepository<CommentEntity> CommentRepository => commentRepository ??
            (commentRepository = new Repository<CommentEntity>(Context));
            
        public IRepository<NewsEntity> NewsRepository => newsRepository ??
            (newsRepository = new Repository<NewsEntity>(Context));

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }
    }
}

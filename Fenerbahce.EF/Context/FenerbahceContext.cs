using Fenerbahce.EF.Mappings;
using Fenerbahce.Models.EntityModels;
using System.Data.Entity;

namespace Fenerbahce.EF.Context
{
    public class FenerbahceContext: DbContext
    {
        public FenerbahceContext() : base("name=FenerbahceDBConnectionString")
        {

        }
        public DbSet<TestEntity> Tests { get; set; }
        public DbSet<SchoolEntity> Schools { get; set; }
        public DbSet<GroupEntity> Groups { get; set; }
        public DbSet<PaymentEntity> Payments { get; set; }
        public DbSet<SportEntity> Sports { get; set; }
        public DbSet<StudentEntity> Students { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder?.Configurations.Add(new TestMapping());
            modelBuilder?.Configurations.Add(new SchoolMapping());
            modelBuilder?.Configurations.Add(new GroupMapping());
            modelBuilder?.Configurations.Add(new SportMapping());
            modelBuilder?.Configurations.Add(new StudentMapping());
            modelBuilder?.Configurations.Add(new PaymentMapping());
            modelBuilder?.Configurations.Add(new InstructorGroupMapping());
            modelBuilder?.Configurations.Add(new StudentParentMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}

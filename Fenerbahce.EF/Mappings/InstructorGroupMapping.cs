﻿using Fenerbahce.Models.EntityModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Fenerbahce.EF.Mappings
{
    public class InstructorGroupMapping : EntityTypeConfiguration<InstructorGroupEntity>
    {
        public InstructorGroupMapping()
        {
            ToTable("dbo.InstructorGroup");
            HasKey(x => new { x.InstructorId, x.GroupId });

            Property(x => x.GroupId).HasColumnName("GroupId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.InstructorId).HasColumnName("InstructorId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Type).HasColumnName("Type").IsRequired().HasMaxLength(50);
            Property(x => x.Salary).HasColumnName("Salary").IsRequired();

            HasRequired(x => x.Instructor).WithMany(y => y.InstructorGroups).HasForeignKey(z => z.InstructorId);
            HasRequired(x => x.Group).WithMany(y => y.InstructorGroups).HasForeignKey(z => z.GroupId);
        }
    }
}

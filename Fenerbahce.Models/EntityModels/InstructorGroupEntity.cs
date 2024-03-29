﻿namespace Fenerbahce.Models.EntityModels
{
    public class InstructorGroupEntity
    {
        public int InstructorId { get; set; }
        public long GroupId { get; set; }
        public int Salary { get; set; }
        public string Type { get; set; }

        public UserEntity Instructor { get; set; }
        public GroupEntity Group { get; set; }
    }
}

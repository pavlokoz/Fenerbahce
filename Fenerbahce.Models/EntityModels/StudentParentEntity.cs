namespace Fenerbahce.Models.EntityModels
{
    public class StudentParentEntity
    {
        public int ParentId { get; set; }
        public long StudentId { get; set; }

        public UserEntity Parent { get; set; }
        public StudentEntity Student { get; set; }
    }
}

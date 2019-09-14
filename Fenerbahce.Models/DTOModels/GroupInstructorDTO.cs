namespace Fenerbahce.Models.DTOModels
{
    public class GroupInstructorDTO
    {
        public int InstructorId { get; set; }
        public long GroupId { get; set; }
        public int Salary { get; set; }
        public string Type { get; set; }
        public InstructorDTO Instructor { get; set; }

    }
}

using System;

namespace Fenerbahce.Models.DTOModels
{
    public class InstructorDTO
    {
        public int InstructorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}

using System;

namespace Fenerbahce.Models.DTOModels
{
    public class StudentDTO
    {
        public long StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Patrimonial { get; set; }
    }
}

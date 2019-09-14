using System;

namespace Fenerbahce.Models.DTOModels.MobileDTO
{
    public class VisitorLogDTO
    {
        public long StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long GroupId { get; set; }
        public bool IsExist { get; set; }
        public DateTime LogDate { get; set; }
    }
}

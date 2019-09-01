using System;

namespace Fenerbahce.Models.EntityModels
{
    public class VisitorLogEntity
    {
        public long VisitorLogId { get; set; }
        public DateTime? VisitorLogDate { get; set; }
        public long StudentId { get; set; }

        public StudentEntity Student { get; set; }
    }
}

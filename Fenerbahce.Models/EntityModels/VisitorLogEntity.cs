using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fenerbahce.Models.EntityModels
{
    public class VisitorLogEntity
    {
        public DateTime VisitorLogDate { get; set; }
        public long StudentId { get; set; }

        [NotMapped]
        public bool IsExist { get; set; }

        public StudentEntity Student { get; set; }
    }
}

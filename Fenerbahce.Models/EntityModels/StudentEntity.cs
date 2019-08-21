using System;
using System.Collections.Generic;

namespace Fenerbahce.Models.EntityModels
{
    public class StudentEntity
    {
        public long StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Patrimonial { get; set; }

        public SportEntity Sport { get; set; }
        public long SportId { get; set; }

        public GroupEntity Group { get; set; }
        public long GroupId { get; set; }

        public IList<PaymentEntity> Payments { get; set; }
    }
}

﻿using System.Collections.Generic;

namespace Fenerbahce.Models.DTOModels
{
    public class GroupDetailDTO: GroupDTO
    {
        public IList<StudentDTO> Students { get; set; }
        public IList<InstructorDTO> Instructors { get; set; }
    }
}

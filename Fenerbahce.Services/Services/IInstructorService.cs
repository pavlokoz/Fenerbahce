﻿using Fenerbahce.Models.EntityModels;
using System.Collections.Generic;

namespace Fenerbahce.Services.Services
{
    public interface IInstructorService
    {
        IList<UserEntity> GetInstructors();
        void AddInstructor(InstructorGroupEntity entity);
    }
}

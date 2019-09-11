using Fenerbahce.Models.EntityModels;
using Fenerbahce.UnitOfWork.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fenerbahce.Services.Services.Impl
{
    public class StudentService: IStudentService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public StudentService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public void Create(StudentEntity entity)
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                uow.StudentRepository.Insert(entity);
                uow.Save();
            }
        }

        public void CreateStudent(StudentEntity student, int parentId)
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                uow.StudentRepository.Insert(student);
                var parentStudent = new StudentParentEntity()
                {
                    ParentId = parentId,
                    StudentId = student.StudentId
                };
                uow.StudentParentRepository.Insert(parentStudent);
                uow.Save();
            }
        }

        public void Delete(StudentEntity entity)
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                uow.StudentRepository.Delete(entity);
                uow.Save();
            }
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public IList<StudentEntity> GetAll()
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var students = uow.StudentRepository.Get().ToList();
                return students;
            }
        }

        public StudentEntity GetById(long id)
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var query = from studentRepo in uow.StudentRepository.Get()
                              join groupRepo in uow.GroupRepository.Get()
                              on studentRepo.GroupId equals groupRepo.GroupId
                              join studentParentRepo in uow.StudentParentRepository.Get()
                              on studentRepo.StudentId equals studentParentRepo.StudentId into studentParentLeft
                              from studentParentRepo in studentParentLeft.DefaultIfEmpty()
                              join parentRepo in uow.UserRepository.Get()
                              on studentParentRepo.ParentId equals parentRepo.UserId into parentLeft
                              from parentRepo in parentLeft.DefaultIfEmpty()
                              where studentRepo.StudentId == id
                              select new { studentRepo, groupRepo, studentParentRepo, parentRepo };
                var student = query.ToList().Select(x => x.studentRepo).Distinct().SingleOrDefault();
                if (student == null)
                {
                    return null;
                }

                student.Parents = student.StudentParents?.Select(x => x.Parent).ToList();
                return student;
            }
        }

        public IList<StudentEntity> Search(string text)
        {
            using (var uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var result = uow.StudentRepository.Get()
                    .Where(x => ((x.FirstName + x.LastName).ToLower()).Contains(text.ToLower()))
                    .ToList();
                var startWithDictionary = new List<StudentEntity>();
                var containsDictionary = new List<StudentEntity>();
                foreach (var item in result)
                {
                    if ((item.LastName + item.FirstName).ToLower().StartsWith(text.ToLower()))
                    {
                        startWithDictionary.Add(item);
                    }
                    else
                    {
                        containsDictionary.Add(item);
                    }
                }
                foreach (var item in containsDictionary)
                {
                    startWithDictionary.Add(item);
                }
                return startWithDictionary;
            }
        }
    }
}

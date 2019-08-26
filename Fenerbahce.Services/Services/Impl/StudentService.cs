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
            throw new NotImplementedException();
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
                var student = uow.StudentRepository.GetByID(id);
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

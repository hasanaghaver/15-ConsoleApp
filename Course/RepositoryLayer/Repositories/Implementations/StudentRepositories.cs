using DomainLayer.Entities;
using RepositoryLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RepositoryLayer.Repositories.Implementations
{
    class StudentRepositories : IRepositories<Student>
    {
        public void Create(Student data)
        {
            throw new NotImplementedException();
        }
        public void Update(int id, Student data)
        {
            throw new NotImplementedException();
        }
        public Student GetById(Predicate<Student> predicate)
        {
            throw new NotImplementedException();
        }
        public void Delete(Student data)
        {
            throw new NotImplementedException();
        }
        public Student GetStudentsByAge(int age)
        {
            throw new NotImplementedException();
        }
        public List<Student> GetAllStudentsByGroupId(int id)
        {
            throw new NotImplementedException();
        }

        public Student SearchForNameOrSurname(string nameOrSurname)
        {
            throw new Exception();
        }

        public List<Student> GetAll(Predicate<Student> predicate)
        {
            throw new NotImplementedException();
        }
    }
}

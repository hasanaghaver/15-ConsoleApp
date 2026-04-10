using DomainLayer.Entities;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Implimentation
{
    public class StudentService : IStudentService
    {
        public void CreateStudent(Student data)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAllByGroupId(int id)
        {
            throw new NotImplementedException();
        }

        public Student GetStudentById(Predicate<Student> predicate)
        {
            throw new NotImplementedException();
        }

        public Student GetStudentsByAge(int age)
        {
            throw new NotImplementedException();
        }

        public Student SearchStudentForNameOrSurname(string nameOrSurname)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(int id, Student data)
        {
            throw new NotImplementedException();
        }
    }
}

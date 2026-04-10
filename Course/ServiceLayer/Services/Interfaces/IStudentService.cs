using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    interface IStudentService
    {
        public void CreateStudent(Student data);
        public void UpdateStudent(int id, Student data);
        public Student GetStudentById(Predicate<Student> predicate);
        public void DeleteStudent(int id);
        public Student GetStudentsByAge(int age);
        public List<Student> GetAllByGroupId(int id);
        public Student SearchStudentForNameOrSurname(string nameOrSurname);
    }
}

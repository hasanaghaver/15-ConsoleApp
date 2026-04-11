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
        public Student CreateStudent(Student data);
        public bool UpdateStudent(int id, Student data);
        public Student GetStudentById(int id);
        public bool DeleteStudent(int id);
        public List<Student> GetStudentsByAge(int age);
        public List<Student> GetAllByGroupId(int id);
        public List<Student> SearchStudentForNameOrSurname(string nameOrSurname);
    }
}

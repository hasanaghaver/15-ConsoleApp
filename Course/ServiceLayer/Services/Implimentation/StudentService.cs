using DomainLayer.Entities;
using ServiceLayer.Services.Interfaces;
using RepositoryLayer.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Implimentation
{
    public class StudentService : IStudentService
    {
        private StudentRepositories _studentRepossitories;
        private int _count = 1;
        public StudentService()
        {
            _studentRepossitories = new();
        }

        public Student CreateStudent(Student data)
        {
            data.Id = _count;
            _count++;
            _studentRepossitories.Create(data);
            return data;
        }

        public bool DeleteStudent(int id)
        {
            Student exsist = GetStudentById(id);
            if (exsist == null) return false;
            _studentRepossitories.Delete(exsist);
            return true;
        }

        public List<Student> GetAllByGroupId(int id)
        {
            List<Student> students = _studentRepossitories.GetAll(i => i.group.Id == id);
            return students;
        }

        public Student GetStudentById(int id)
        {
            Student exsist = _studentRepossitories.Get(i => i.Id == id);
            return exsist;
        }

        public List<Student> GetStudentsByAge(int age)
        {
            List<Student> exsist = _studentRepossitories.GetAll(i=> i.Age == age);
            return exsist;
        }

        public List<Student> SearchStudentForNameOrSurname(string nameOrSurname)
        {
            List<Student> exsistfull = _studentRepossitories.GetAll(i=>i.Name.ToLower() == nameOrSurname);
            List<Student> exsistsurname = _studentRepossitories.GetAll(i=>i.Surname.ToLower() == nameOrSurname);
            exsistfull.AddRange(exsistsurname);
            return exsistfull;
        }

        public bool UpdateStudent(int id, Student data)
        {
            Student result = GetStudentById(id);
            if (result == null)
            {
                return false;
            }
            _studentRepossitories.Update(id, data);
            return true;
        }
    }
}

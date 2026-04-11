using DomainLayer.Entities;
using RepositoryLayer.Data;
using RepositoryLayer.Exceptions;
using RepositoryLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RepositoryLayer.Repositories.Implementations
{
    public class StudentRepositories : IRepositories<Student>
    {
        public void Create(Student data)
        {
            try
            {
                if (data is null) throw new NotFoudException("Empty data!!");
                AppDbContext<Student>.datas.Add(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Update(int id, Student data)
        {
            var existGroup = AppDbContext<Student>.datas.Find(i => i.Id == id);
            if (existGroup != null)
            {
                existGroup.Name = data.Name;
                existGroup.Surname = data.Surname;
                existGroup.Age = data.Age;
                existGroup.group = data.group;
            }
        }
        public Student Get(Predicate<Student> predicate)
        {
            return predicate != null ? AppDbContext<Student>.datas.Find(predicate) : null;
        }
        public List<Student> GetAll(Predicate<Student> predicate)
        {
            return predicate != null ? AppDbContext<Student>.datas.FindAll(predicate) : null;
        }
        public void Delete(Student data)
        {
            AppDbContext<Student>.datas.Remove(data);
        }
    }
}

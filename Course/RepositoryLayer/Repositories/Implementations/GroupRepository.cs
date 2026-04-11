using DomainLayer.Entities;
using RepositoryLayer.Data;
using RepositoryLayer.Exceptions;
using RepositoryLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories.Implementations
{
    public class GroupRepository : IRepositories<CourseGroup>
    {
        public void Create(CourseGroup data)
        {
            try
            {
                if (data is null) throw new NotFoudException("Empty data!");
                AppDbContext<CourseGroup>.datas.Add(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Update(int id, CourseGroup data)
        {
            var existGroup = AppDbContext<CourseGroup>.datas.Find(i => i.Id == id);
            if (existGroup != null)
            {
                existGroup.Name = data.Name;
                existGroup.Teacher = data.Teacher;
                existGroup.Room = data.Room;
            }
        }
        public void Delete(CourseGroup data)
        {
            AppDbContext<CourseGroup>.datas.Remove(data);
        }
        public CourseGroup Get(Predicate<CourseGroup> predicate)
        {
            return predicate != null ? AppDbContext<CourseGroup>.datas.Find(predicate) : null;
        }
 
        public Student SearcdForGroupsByName(string name)
        {
            throw new Exception();
        }

        public List<CourseGroup> GetAll(Predicate<CourseGroup> predicate)
        {
            return predicate != null ? AppDbContext<CourseGroup>.datas.FindAll(predicate) : null;
        }
    }
}

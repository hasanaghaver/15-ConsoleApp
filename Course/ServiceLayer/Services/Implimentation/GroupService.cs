using DomainLayer.Entities;
using RepositoryLayer.Repositories.Implementations;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Implimentation
{
    public class GroupService : IGroupService
    {
        private int _count = 1;
        private GroupRepository _groupRepository;
        public GroupService()
        {
            _groupRepository = new GroupRepository();
        }
        public CourseGroup CreateGroup(CourseGroup data)
        {
            CourseGroup group = SearcdForGroupsByName(data.Name);
            if (group is null)
            {
                data.Id = _count;
                _groupRepository.Create(data);
                _count++;
                return data;
            }
            return null;
        }

        public bool DeleteGroup(int id)
        {
            CourseGroup result = GetGroupById(id);
            if (result == null)
            {
                return false;
            }
            _groupRepository.Delete(result);
            return true;
        }

        public List<CourseGroup> GetAllGroup()
        {
            List<CourseGroup> datas = _groupRepository.GetAll(i=> i.Id>0);
            return datas;
        }

        public List<CourseGroup> GetByRoom(int room)
        {
            List<CourseGroup> datas = _groupRepository.GetAll(i => i.Room == room);
            return datas;
        }

        public List<CourseGroup> GetByTeacher(string teacherName)
        {
            List<CourseGroup> datas = _groupRepository.GetAll(i => i.Teacher.ToLower() == teacherName.Trim().ToLower());
            return datas;
        }

        public CourseGroup GetGroupById(int id)
        {
            CourseGroup course = _groupRepository.Get(i => i.Id == id);
            if (course is null) return null;
            return course;
        }

        public CourseGroup SearcdForGroupsByName(string name)
        {
            CourseGroup course = _groupRepository.Get(i => i.Name.ToLower() == name.Trim().ToLower());
            if (course is null) return null;
            return course;
        }

        public bool UpdateGroup(int id, CourseGroup data)
        {
            CourseGroup result = GetGroupById(id);
            if (result == null)
            {
                return false;
            }
            _groupRepository.Update(id, data);
            return true;
        }
    }
}

using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    interface IGroupService
    {
        public CourseGroup CreateGroup(CourseGroup data);
        public void UpdateGroup(int id, CourseGroup data);
        public bool DeleteGroup(int id);
        public CourseGroup GetGroupById(int id);
        public List<CourseGroup> GetByTeacher(string teacherName);
        public List<CourseGroup> GetByRoom(int room);
        public List<CourseGroup> GetAllGroup();
        public List<CourseGroup> SearcdForGroupsByName(string name);
    }
}

using CourseApp.Helper;
using DomainLayer.Entities;
using ServiceLayer.Services.Implimentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Common
{
    class GroupController
    {
        private GroupService _groupService;
        public GroupController()
        {
            _groupService = new GroupService();
        }
        public void Create()
        {
            Console.Clear();
            Design.MYCw(ConsoleColor.Blue, "Enter Group Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Teacher Name:");
            string teachername = Console.ReadLine();
        RoomNum: Console.WriteLine("Enter room number:");
            string room = Console.ReadLine();
            if (!int.TryParse(room, out int roomNum))
            {
                Design.MYCw(ConsoleColor.Red, "Enter correct number:");
                goto RoomNum;
            }
            else
            {
                CourseGroup courseGroup = new CourseGroup { Name = name, Teacher = teachername, Room = roomNum };
                CourseGroup result = _groupService.CreateGroup(courseGroup);
                Design.MYCw(ConsoleColor.Green, $"Id:{result.Id}  Name: {result.Name} Teacher: {result.Teacher} Room: {result.Room}");
            }
        }
        public void GetById()
        {
            Console.Clear();
        ID: Design.MYCw(ConsoleColor.Blue, "Enter Group Id:");
            string strId = Console.ReadLine();
            if (!int.TryParse(strId, out int idNum))
            {
                Design.MYCw(ConsoleColor.Red, "Enter correct number!!");
                goto ID;
            }
            else
            {
                CourseGroup result = _groupService.GetGroupById(idNum);
                if (result == null)
                {
                    Design.MYCw(ConsoleColor.Red, "Group not foud");
                }
                else
                {
                    Design.MYCw(ConsoleColor.Green, $"Id:{result.Id}  Name: {result.Name} Teacher: {result.Teacher} Room: {result.Room}");
                }
            }
        }
        public void GetByTeacher()
        {
            Console.Clear();
            Design.MYCw(ConsoleColor.Blue, "Enter Teacher Name:");
            string teacherName = Console.ReadLine();
            List<CourseGroup> result = _groupService.GetByTeacher(teacherName);
            if (result.Count == 0)
            {
                Design.MYCw(ConsoleColor.Red, "Group not found");
            }
            else
            {
                foreach (var item in result)
                {
                    Design.MYCw(ConsoleColor.Green, $"Id:{item.Id}  Name: {item.Name} Teacher: {item.Teacher} Room: {item.Room}");
                }
            }
                

        }
        public void GetByRoom()
        {
            Console.Clear();
        Room: Design.MYCw(ConsoleColor.Blue, "Enter room number:");
            string room = Console.ReadLine();
            if (!int.TryParse(room,out int roomNum))
            {
                Design.MYCw(ConsoleColor.Red, "Enter correct number!!");
                goto Room;
            }
            else
            {
                List<CourseGroup> result = _groupService.GetByRoom(roomNum);
                if (result.Count == 0)
                {
                    Design.MYCw(ConsoleColor.Red, "Group not found");
                }
                else
                {
                    foreach (var item in result)
                    {
                        Design.MYCw(ConsoleColor.Green, $"Id:{item.Id}  Name: {item.Name} Teacher: {item.Teacher} Room: {item.Room}");
                    }
                }
            }
        }
        public void GetAll()
        {
            Console.Clear();
            List<CourseGroup> result = _groupService.GetAllGroup();
            if (result.Count == 0)
            {
                Design.MYCw(ConsoleColor.Red, "Create a group first!");
            }
            else
            {
                foreach (var item in result)
                {
                    Design.MYCw(ConsoleColor.Green, $"Id:{item.Id}  Name: {item.Name} Teacher: {item.Teacher} Room: {item.Room}");
                }
            }
        }
        public void Delete()
        {
            Console.Clear();
        DeleteId: Design.MYCw(ConsoleColor.Blue, "Enter group Id:");
            string id = Console.ReadLine();
            if (!int.TryParse(id, out int idNum))
            {
                Design.MYCw(ConsoleColor.Red, "Enter correct number!!");
                goto DeleteId;
            }
            else
            {
                bool result = _groupService.DeleteGroup(idNum);
                if (result)
                {
                    Design.MYCw(ConsoleColor.Green, "Group deleted");
                }
                else
                {
                    Design.MYCw(ConsoleColor.Red, "Don't have this group");
                }
            }
        }
    }
}

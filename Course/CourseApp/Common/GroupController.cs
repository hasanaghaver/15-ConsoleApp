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
                if (roomNum<0)
                {
                    Design.MYCw(ConsoleColor.Red, "Room number must be possitive, re-enter");
                    goto RoomNum;
                }
                CourseGroup courseGroup = new CourseGroup { Name = name.Trim(), Teacher = teachername.Trim(), Room = roomNum };
                CourseGroup result = _groupService.CreateGroup(courseGroup);
                if (result is null)
                {
                    Design.MYCw(ConsoleColor.Red, "Group alredy exsist!");
                }
                else
                {
                    Design.MYCw(ConsoleColor.Green, $"Id:{result.Id}  Name: {result.Name} Teacher: {result.Teacher} Room: {result.Room}");
                }
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
            if (!int.TryParse(room, out int roomNum))
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
        public void Update()
        {
            Console.Clear();
        UpdateId: Design.MYCw(ConsoleColor.Blue, "Enter Group Id to Update:");
            string strId = Console.ReadLine();

            if (!int.TryParse(strId, out int idNum))
            {
                Design.MYCw(ConsoleColor.Red, "Enter correct number!!");
                goto UpdateId;
            }

            var existGroup = _groupService.GetGroupById(idNum);
            if (existGroup == null)
            {
                Design.MYCw(ConsoleColor.Red, "Group not found!");
                return;
            }

            Console.WriteLine($"Current Name: {existGroup.Name}. Enter New Name(leave blank to keep):");
            string newName = Console.ReadLine();
            if (string.IsNullOrEmpty(newName)) newName = existGroup.Name; 

            Console.WriteLine($"Current Teacher: {existGroup.Teacher}. Enter New Teacher:");
            string newTeacher = Console.ReadLine();
            if (string.IsNullOrEmpty (newTeacher)) newTeacher = existGroup.Teacher;

        NewRoom: Console.WriteLine($"Current Room: {existGroup.Room}. Enter New Room:");
            if (!int.TryParse(Console.ReadLine(), out int newRoom))
            {
                Design.MYCw(ConsoleColor.Red, "Enter correct room number:");
                goto NewRoom;
            }
            CourseGroup updatedData = new CourseGroup { Name = newName.Trim(), Teacher = newTeacher.Trim(), Room = newRoom };
            bool result = _groupService.UpdateGroup(idNum, updatedData);
            if (result)
            {
                Design.MYCw(ConsoleColor.Green, "Group successfully updated!");
            }
            else
            {
                Design.MYCw(ConsoleColor.Red, "Empty data!!");
            }
        }
        public void GetByName()
        {
            Console.Clear();
            Design.MYCw(ConsoleColor.Blue, "Enter Group Name:");
            string groupName = Console.ReadLine();
            CourseGroup result = _groupService.SearcdForGroupsByName(groupName);
            if (result is null)
            {
                Design.MYCw(ConsoleColor.Red, "Group not found");
            }
            else
            {
                Design.MYCw(ConsoleColor.Green, $"Id:{result.Id}  Name: {result.Name} Teacher: {result.Teacher} Room: {result.Room}");
            }
        }
    }
}

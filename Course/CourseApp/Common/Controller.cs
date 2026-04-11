using CourseApp.Helper;
using DomainLayer.Entities;
using ServiceLayer.Services.Implimentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CourseApp.Common
{
    class Controller
    {
        private GroupService _groupService;
        private StudentService _studentService;
        public Controller()
        {
            _groupService = new GroupService();
            _studentService = new StudentService();
        }
        public void GroupCreate()
        {
            Console.Clear();
            Design.MYCw(ConsoleColor.Blue, "Enter Group Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Teacher Name:");
            string teachername = Console.ReadLine();
        RoomNum: Design.MYCw(ConsoleColor.Blue, "Enter room number:");
            string room = Console.ReadLine();
            if (!int.TryParse(room, out int roomNum))
            {
                Design.MYCw(ConsoleColor.Red, "Enter correct number:");
                goto RoomNum;
            }
            else
            {
                if (roomNum < 0)
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
        public void GroupGetById()
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
        public void GroupGetByTeacher()
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
        public void GroupGetByRoom()
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
        public void GroupGetAll()
        {
            List<CourseGroup> result = _groupService.GetAllGroup();
            if (result.Count == 0)
            {
                Design.MYCw(ConsoleColor.Red, "Create a group first!");
            }
            else
            {
                foreach (var item in result)
                {
                    Design.MYCw(ConsoleColor.Yellow, $"Id:{item.Id}  Name: {item.Name} Teacher: {item.Teacher} Room: {item.Room}");
                }
            }
        }
        public void GroupDelete()
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
        public void GroupUpdate()
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

            Console.WriteLine($"Current Teacher: {existGroup.Teacher}. Enter New Teacher:(leave blank to keep)");
            string newTeacher = Console.ReadLine();
            if (string.IsNullOrEmpty(newTeacher)) newTeacher = existGroup.Teacher;

            NewRoom: Design.MYCw(ConsoleColor.Blue, $"Current Room: {existGroup.Room}. Enter New Room:");
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
        public void GroupGetByName()
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
        public void Exit()
        {
            Design.MYCw(ConsoleColor.Magenta, "Press any button to exit:");
            Console.ReadKey(true);
            Console.Clear();
        }
        public void StudentCreate()
        {
            Console.Clear();
            List<CourseGroup> groups = _groupService.GetAllGroup();
            if (groups.Count == 0)
            {
                Design.MYCw(ConsoleColor.Red, "Create group first");
                Exit();
            }
            else
            {
                Design.MYCw(ConsoleColor.Blue, "Enter student's Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter student's Surname:");
                string surnamename = Console.ReadLine();
            Age: Design.MYCw(ConsoleColor.Blue, "Enter student's age(17+):");
                string age = Console.ReadLine();
                if (!int.TryParse(age, out int ageNum))
                {
                    Design.MYCw(ConsoleColor.Red, "Enter correct number:");
                    goto Age;
                }
                if (ageNum < 17)
                {
                    Design.MYCw(ConsoleColor.Red, "Age must be possitive and 17+, re-enter");
                    goto Age;
                }
                Console.WriteLine("Enter group name this list:");
                GroupGetAll();
            Group: string group = Console.ReadLine();
                CourseGroup exsistGroup = _groupService.SearcdForGroupsByName(group);
                if (exsistGroup == null)
                {
                    Design.MYCw(ConsoleColor.Red, "Don't have this group, re-enter");
                    goto Group;
                }
                Student student = new Student { Name = name.Trim(), Surname = surnamename.Trim(), Age = ageNum, group = exsistGroup };
                Student result = _studentService.CreateStudent(student);
                Design.MYCw(ConsoleColor.Green, $"Id:{result.Id}  Name: {result.Name} Surname: {result.Surname} Age: {result.Age} Group: {result.group.Name}");
            }
        }
        public void StudentUpdate()
        {
            Console.Clear();
            List<CourseGroup> groups = _groupService.GetAllGroup();
            if (groups.Count == 0)
            {
                Design.MYCw(ConsoleColor.Red, "Create group first");
                Exit();
            }
        UpdateId: Design.MYCw(ConsoleColor.Blue, "Enter Student Id to Update:");
            string strId = Console.ReadLine();

            if (!int.TryParse(strId, out int idNum))
            {
                Design.MYCw(ConsoleColor.Red, "Enter correct number!!");
                goto UpdateId;
            }
            var existStudent = _studentService.GetStudentById(idNum);
            if (existStudent == null)
            {
                Design.MYCw(ConsoleColor.Red, "Student not found!");
                return;
            }

            Console.WriteLine($"Current Name: {existStudent.Name}. Enter New Name(leave blank to keep):");
            string newName = Console.ReadLine();
            if (string.IsNullOrEmpty(newName)) newName = existStudent.Name;

            Console.WriteLine($"Current Surname: {existStudent.Surname}. Enter New Surname (leave blank to keep):");
            string newSurname = Console.ReadLine();
            if (string.IsNullOrEmpty(newSurname)) newSurname = existStudent.Surname;

            NewAge: Console.WriteLine($"Current Age: {existStudent.Age}. Enter New Age (leave blank to keep):");
            string age = Console.ReadLine();
            int newAge;
            if (string.IsNullOrEmpty(age))
            {
                newAge = existStudent.Age;
            }
            else
            {
                if (!int.TryParse(age, out newAge))
                {
                    Design.MYCw(ConsoleColor.Red, "Enter correct age:");
                    goto NewAge;
                }
                if (newAge < 17)
                {
                    Design.MYCw(ConsoleColor.Red, "Age must be 17+");
                    goto NewAge;
                }
            }
            Console.WriteLine($"Current Group: {existStudent.group.Name}. Enter New Group name(Select this list):");
            GroupGetAll();
        Group: string newGroupname = Console.ReadLine();
            CourseGroup exsistGroup = new();
            if (string.IsNullOrEmpty(newGroupname))
            {
                exsistGroup = existStudent.group;
            }
            else
            {
                exsistGroup = _groupService.SearcdForGroupsByName(newGroupname);
                if (exsistGroup == null)
                {
                    Design.MYCw(ConsoleColor.Red, "Don't have this group, re-enter");
                    goto Group;
                }
            }
            Student updatedData = new Student { Name = newName.Trim(), Surname = newSurname.Trim(), Age = newAge, group = exsistGroup };
            bool result = _studentService.UpdateStudent(idNum, updatedData);
            if (result)
            {
                Design.MYCw(ConsoleColor.Green, "Student successfully updated!");
            }
            else
            {
                Design.MYCw(ConsoleColor.Red, "Empty data!!");
            }
        }
        public void StudentDelete()
        {
            Console.Clear();
        DeleteId: Design.MYCw(ConsoleColor.Blue, "Enter student Id:");
            string id = Console.ReadLine();
            if (!int.TryParse(id, out int idNum))
            {
                Design.MYCw(ConsoleColor.Red, "Enter correct number!!");
                goto DeleteId;
            }
            else
            {
                bool result = _studentService.DeleteStudent(idNum);
                if (result)
                {
                    Design.MYCw(ConsoleColor.Green, "Student deleted");
                }
                else
                {
                    Design.MYCw(ConsoleColor.Red, "Don't have this student");
                }
            }
        }
        public void StudentGetID()
        {
            Console.Clear();
        ID: Design.MYCw(ConsoleColor.Blue, "Enter Student Id:");
            string strId = Console.ReadLine();
            if (!int.TryParse(strId, out int idNum))
            {
                Design.MYCw(ConsoleColor.Red, "Enter correct number!!");
                goto ID;
            }
            else
            {
                Student result = _studentService.GetStudentById(idNum);
                if (result == null)
                {
                    Design.MYCw(ConsoleColor.Red, "Student not foud");
                }
                else
                {
                    string groupName = result.group != null ? result.group.Name : "Null";
                    Design.MYCw(ConsoleColor.Green, $"Id:{result.Id}  Name: {result.Name} Surname: {result.Surname} Age: {result.Age} Group: {result.group.Name}");
                }
            }
        }
        public void StudentGetByAge()
        {
            Console.Clear();
        Age: Design.MYCw(ConsoleColor.Blue, "Enter student age:");
            string age = Console.ReadLine();
            if (!int.TryParse(age, out int ageNum))
            {
                Design.MYCw(ConsoleColor.Red, "Enter correct number!!");
                goto Age;
            }
            else
            {
                List<Student> result = _studentService.GetStudentsByAge(ageNum);
                if (result.Count == 0)
                {
                    Design.MYCw(ConsoleColor.Red, "Student not found");
                }
                else
                {
                    foreach (var item in result)
                    {
                        string groupName = item.group != null ? item.Name : "Null";
                        Design.MYCw(ConsoleColor.Green, $"Id:{item.Id}  Name: {item.Name} Surname: {item.Surname} Age: {item.Age} Group: {item.group.Name}");
                    }
                }
            }
        }
        public void StudentGetByNameOrSurname()
        {
            Console.Clear();
            Design.MYCw(ConsoleColor.Blue, "Enter student name or surname:");
            string nameOrSurname = Console.ReadLine();
            List<Student> students = _studentService.SearchStudentForNameOrSurname(nameOrSurname.Trim().ToLower());
            if (students.Count == 0)
            {
                Design.MYCw(ConsoleColor.Red, "Students not found");
            }
            else
            {
                foreach (var item in students)
                {
                    string groupName = item.group != null ? item.group.Name : "Null";
                    Design.MYCw(ConsoleColor.Green, $"Id:{item.Id}  Name: {item.Name} Surname: {item.Surname} Age: {item.Age} Group: {item.group.Name}");
                }
            }
        }
        public void StudentGetByGroupId()
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
                List<Student> students = _studentService.GetAllByGroupId(idNum);
                if (students.Count == 0)
                {
                    Design.MYCw(ConsoleColor.Red, "Students not found");
                }
                else
                {
                    foreach (var item in students)
                    {
                        string groupName = item.group != null ? item.group.Name : "null";
                        Design.MYCw(ConsoleColor.Green, $"Id:{item.Id}  Name: {item.Name} Surname: {item.Surname} Age: {item.Age} Group: {item.group.Name}");
                    }
                }
            }
        }
    }
}

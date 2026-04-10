using CourseApp.Common;
using CourseApp.Helper;
using System.Runtime.CompilerServices;

namespace CourseApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GroupController _groupController = new();
            bool a = true;
            while (a)
            {
                Design.MYCw(ConsoleColor.DarkCyan, "What do you want? \n1-Group \n2-Student  \n3-Exit");
            EnterOption1: string option1 = Console.ReadLine();
                if (!int.TryParse(option1, out int result1))
                {
                    Design.MYCw(ConsoleColor.Red, "Incorrect option");
                    goto EnterOption1;
                }
                else
                {
                    switch (result1)
                    {
                        case 1:
                            Console.Clear();
                            Design.MYCw(ConsoleColor.Yellow, "1 - Create Group \n2 - Update group    \n3 - Delete Group   \n4 - Get group  by id" +
                                " \n5 - Get all groups  by teacher  \n6 - Get all groups by room \n7 - Get all groups ");
                            string option2 = Console.ReadLine();
                            if (!int.TryParse(option2, out int result2))
                            {
                                Design.MYCw(ConsoleColor.Red, "Incorrect option");
                            }
                            else
                            {
                                switch (result2)
                                {
                                    case 1:
                                        _groupController.Create();
                                        break;
                                    case 3:
                                        _groupController.Delete();
                                        break;
                                    case 4:
                                        _groupController.GetById();
                                        break;
                                    case 5:
                                        _groupController.GetByTeacher();
                                        break;
                                    case 6:
                                        _groupController.GetByRoom();
                                        break;
                                    case 7:
                                        _groupController.GetAll();
                                        break;
                                }
                            }
                            break;
                        case 3:
                            a = false;
                            break;
                        
                    }
                }
            }
            
            
        }
    }
}

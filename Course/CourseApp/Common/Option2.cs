using CourseApp.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Common
{
    public class Option2
    {
        private GroupController _groupController;
        public Option2()
        {
            _groupController = new();
        }
        public void Switch()
        {
            Console.Clear();
            Design.MYCw(ConsoleColor.Yellow, "1 - Create Group \n2 - Update group    \n3 - Delete Group   \n4 - Get group  by id \n5 - Get group by name" +
               " \n6 - Get all groups  by teacher  \n7 - Get all groups by room \n8 - Get all groups  \n9 - Exit");
        Option2: string option2 = Console.ReadLine();
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
                    case 2:
                        _groupController.Update();
                        break;
                    case 3:
                        _groupController.Delete();
                        break;
                    case 4:
                        _groupController.GetById();
                        break;
                    case 5:
                        _groupController.GetByName();
                        break;
                    case 6:
                        _groupController.GetByTeacher();
                        break;
                    case 7:
                        _groupController.GetByRoom();
                        break;
                    case 8:
                        _groupController.GetAll();
                        break;
                    case 9:
                        break;
                    default:
                        Design.MYCw(ConsoleColor.Red, "Unknown option,Enter retry");
                        goto Option2;
                }
            }
        }
    }
}

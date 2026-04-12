using CourseApp.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Common
{
    public class Options
    {
        private Controller _controller;
        public Options()
        {
            _controller = new();
        }
        public void Switch1()
        {
            Console.Clear();
            Design.MYCw(ConsoleColor.Cyan, "┌──────────────────────────────────────────────────────────┐");
            Design.MYCw(ConsoleColor.Cyan, "│                   GROUP OPERATIONS MENU                  │");
            Design.MYCw(ConsoleColor.Cyan, "├─────────────────────────────┬────────────────────────────┤");
            Design.MYCw(ConsoleColor.Yellow, "│  1. Create Group            │  5. Get Group by Name      │");
            Design.MYCw(ConsoleColor.Yellow, "│  2. Update Group            │  6. Get Groups by Teacher  │");
            Design.MYCw(ConsoleColor.Yellow, "│  3. Delete Group            │  7. Get Groups by Room     │");
            Design.MYCw(ConsoleColor.Yellow, "│  4. Get Group by ID         │  8. Get All Groups         │");
            Design.MYCw(ConsoleColor.Cyan, "├─────────────────────────────┴────────────────────────────┤");
            Design.MYCw(ConsoleColor.Red, "│                      9. EXIT                             │");
            Design.MYCw(ConsoleColor.Cyan, "└──────────────────────────────────────────────────────────┘");
            Design.MYCw(ConsoleColor.DarkCyan, "\n[?] Enter your choise: ");
        Option2: string option2 = Console.ReadLine();
            if (!int.TryParse(option2, out int result2))
            {
                Design.MYCw(ConsoleColor.Red, "[!] Invalid input. Please enter a number.");
                goto Option2;
            }
            else
            {
                switch (result2)
                {
                    case 1:
                        _controller.GroupCreate();
                        _controller.Exit();
                        break;
                    case 2:
                        _controller.GroupUpdate();
                        _controller.Exit();
                        break;
                    case 3:
                        _controller.GroupDelete();
                        _controller.Exit();
                        break;
                    case 4:
                        _controller.GroupGetById();
                        _controller.Exit();
                        break;
                    case 5:
                        _controller.GroupGetByName();
                        _controller.Exit();
                        break;
                    case 6:
                        _controller.GroupGetByTeacher();
                        _controller.Exit();
                        break;
                    case 7:
                        _controller.GroupGetByRoom();
                        _controller.Exit();
                        break;
                    case 8:
                        _controller.GroupGetAll();
                        _controller.Exit();
                        break;
                    case 9:
                        Console.Clear();
                        break;
                    default:
                        Design.MYCw(ConsoleColor.Red, "[!] Unknown option! Please try again.");
                        goto Option2;
                }
            }
        }
        public void Switch2()
        {
            Console.Clear();
            Design.MYCw(ConsoleColor.Cyan, "┌──────────────────────────────────────────────────────────┐");
            Design.MYCw(ConsoleColor.Cyan, "│                 STUDENT OPERATIONS MENU                  │");
            Design.MYCw(ConsoleColor.Cyan, "├─────────────────────────────┬────────────────────────────┤");
            Design.MYCw(ConsoleColor.Yellow, "│  1. Create Student          │  5. Get Students by Age    │");
            Design.MYCw(ConsoleColor.Yellow, "│  2. Update Student          │  6. Search by Name/Surname │");
            Design.MYCw(ConsoleColor.Yellow, "│  3. Delete Student          │  7. Get by Group ID        │");
            Design.MYCw(ConsoleColor.Yellow, "│  4. Get Student by ID       │                            │");
            Design.MYCw(ConsoleColor.Cyan, "├─────────────────────────────┴────────────────────────────┤");
            Design.MYCw(ConsoleColor.Red, "│                      8. EXIT                             │");
            Design.MYCw(ConsoleColor.Cyan, "└──────────────────────────────────────────────────────────┘");
            Design.MYCw(ConsoleColor.DarkCyan, "\n[?] Enter your choise: ");
        Option2: string option2 = Console.ReadLine();
            if (!int.TryParse(option2, out int result2))
            {
                Design.MYCw(ConsoleColor.Red, "[!] Invalid input. Please enter a number."); goto Option2;
            }
            else
            {
                switch (result2)
                {
                    case 1:
                        _controller.StudentCreate();
                        _controller.Exit();
                        break;
                    case 2:
                        _controller.StudentUpdate();
                        _controller.Exit();
                        break;
                    case 3:
                        _controller.StudentDelete();
                        _controller.Exit();
                        break;
                    case 4:
                        _controller.StudentGetID();
                        _controller.Exit();
                        break;
                    case 5:
                        _controller.StudentGetByAge();
                        _controller.Exit();
                        break;
                    case 6:
                        _controller.StudentGetByNameOrSurname();
                        _controller.Exit();
                        break;
                    case 7:
                        _controller.StudentGetByGroupId();
                        _controller.Exit();
                        break;
                    case 8:
                        Console.Clear();
                        break;
                    default:
                        Design.MYCw(ConsoleColor.Red, "[!] Unknown option! Please try again.");
                        goto Option2;
                }
            }
        }
    }
}

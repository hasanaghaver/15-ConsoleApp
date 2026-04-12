using CourseApp.Common;
using CourseApp.Helper;
using System.Runtime.CompilerServices;

namespace CourseApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Options option = new();

            bool a = true;
            while (a)
            {
                Console.Clear();
                Console.Clear();
                Design.MYCw(ConsoleColor.Cyan, "┌──────────────────────────────────────────────────────────┐");
                Design.MYCw(ConsoleColor.Cyan, "│                COURSE MANAGEMENT SYSTEM                  │");
                Design.MYCw(ConsoleColor.Cyan, "├──────────────────────────────────────────────────────────┤");
                Design.MYCw(ConsoleColor.Cyan, "│                                                          │");
                Design.MYCw(ConsoleColor.Yellow, "│               1. GROUP OPERATIONS                        │");
                Design.MYCw(ConsoleColor.Yellow, "│               2. STUDENT OPERATIONS                      │");
                Design.MYCw(ConsoleColor.Yellow, "│               3. EXIT SYSTEM                             │");
                Design.MYCw(ConsoleColor.Cyan, "│                                                          │");
                Design.MYCw(ConsoleColor.Cyan, "└──────────────────────────────────────────────────────────┘");

                Design.MYCw(ConsoleColor.DarkCyan, "\n[?] Enter your choise: ");
            EnterOption1: string option1 = Console.ReadLine();
                if (!int.TryParse(option1, out int result1))
                {
                    Design.MYCw(ConsoleColor.Red, "[!] Incorrect option");
                    goto EnterOption1;
                }
                else
                {
                    switch (result1)
                    {
                        case 1:
                            option.Switch1();
                            break;
                        case 2:
                            option.Switch2();
                            break;
                        case 3:
                            Design.MYCw(ConsoleColor.Magenta, "\n[i] Shutting down... Goodbye!");
                            a = false;
                            break;
                        default:
                            Design.MYCw(ConsoleColor.Red, "[!] Unknown option,Enter retry");
                            goto EnterOption1;

                    }
                }
            }


        }
    }
}

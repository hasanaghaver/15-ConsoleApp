using CourseApp.Common;
using CourseApp.Helper;
using System.Runtime.CompilerServices;

namespace CourseApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Option2 option2 = new();
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
                            option2.Switch();
                            break;
                        case 2:
                            break;
                        case 3:
                            a = false;
                            break;
                        default:
                            Design.MYCw(ConsoleColor.Red, "Unknown option,Enter retry");
                            goto EnterOption1;

                    }
                }
            }


        }
    }
}

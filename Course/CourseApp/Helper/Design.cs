using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Helper
{
    public static class Design
    {
        public static void MYCw(ConsoleColor color,string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
        }
    }
}

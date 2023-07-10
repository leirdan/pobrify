using System;

namespace pobrify.Utils
{
    static class Exit
    {
        public static bool ExitProgram()
        {
            Console.WriteLine("Do you want to finish this program? (yes/no)");
            string res = Console.ReadLine();
            if (res != "no")
            {
                return true;
            }
            return false;
        }
    }
}

using System;

namespace pobrify.Utils
{
    static class Continue
    {
        public static bool ShouldContinue()
        {
            Console.WriteLine("Do you want to continue? (yes / no)");
            string res = Console.ReadLine();
            return res.ToLower() == "yes";
        }
    }
}

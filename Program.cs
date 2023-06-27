using System;

namespace pobrify
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string main = "spotify.com/user/leirdan";
            string[] aux = main.Split('/');
            Console.WriteLine(aux[2]);
            // "leirdan"

            Console.ReadLine();
        }
    }
}

using System;

namespace pobrify
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string main = "spotify.com/user/leirdan";
                var formatter = new URLFormatter("https://open.spotify.com/intl-pt/album/1XtnMkxeV9wdELLvBZxktL");
                //string[] aux = main.Split('/'); 
                //Console.WriteLine(aux[2]);
                // "leirdan"
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.ParamName);
            }

            Console.ReadLine();
        }
    }
}

using System;
using System.Text.RegularExpressions;

namespace pobrify
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string url = "https://open.spotify.com/intl-pt/tRaCk/2JWP3EPVXHxnYatwaWkf08&si=36f88f89fcce4fcd";
                var formatter = new URLFormatter(url);
                var id = formatter.GetID(url);
                Console.WriteLine($"O id é: {id}");
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

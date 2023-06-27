using System;

namespace pobrify
{
    /// <summary>
    /// Representa um formatador de URL que coleta informações relevantes em uma URL do Spotify.
    /// </summary>
    internal class URLFormatter
    {
        private readonly string _path;
        public string URL { get; }
        public URLFormatter(String url)
        {
            if (String.IsNullOrEmpty(url)) throw new ArgumentException("O argumento URL não pode ser nulo ou estar vazio!", nameof(URL));
            else URL = url;
            #region rawVersion
            //if (url.Contains("/album"))
            //{
            //    var len = "/album".Length;
            //    var aux = url.IndexOf("/album");
            //    var id = url.Substring(aux + len + 1);
            //    Console.WriteLine($"É um álbum de ID:${id}");
            //}
            //else if (url.Contains("/track"))
            //{
            //    var len = "/track".Length;
            //    var aux = url.IndexOf("/track");
            //    var id = url.Substring(aux + len + 1);
            //    Console.WriteLine($"É uma música de ID:${id}");
            //}
            //else if (url.Contains("/playlist"))
            //{
            //    var len = "/playlist".Length;
            //    var aux = url.IndexOf("/playlist");
            //    var id = url.Substring(aux + len + 1);
            //    Console.WriteLine($"É uma playlist de ID:${id}");
            //}
            //else
            //{
            //    throw new ArgumentException("URL em formato incorreto.");
            //}
            #endregion
            #region softVersion
            if (url.Contains("/album") || url.Contains("/track") || url.Contains("/playlist"))
            {
                string[] aux = url.Split('/');
                Console.WriteLine($"É um(a) {aux[4]} de ID {aux[5]}.");
            }
            else
            {
                throw new ArgumentException("URL em formato incorreto.");
            }
            #endregion
        }
    }
}

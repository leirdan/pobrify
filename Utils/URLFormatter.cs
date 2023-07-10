using System;

namespace pobrify
{
    /// <summary>
    /// Representa um formatador de URL que coleta informações relevantes em uma URL do Spotify.
    /// </summary>
    internal class URLFormatter
    {
        public string URL { get; }
        public URLFormatter(String url)
        {
            if (String.IsNullOrEmpty(url)) throw new ArgumentException("O argumento URL não pode ser nulo ou estar vazio!", nameof(URL));
            else URL = url;
        }

        public string GetID(string url)
        {
            string var = url.ToLower();
            #region softVersion
            if (var.Contains("/album") || var.Contains("/track") || var.Contains("/playlist"))
            {
                // Separa e adiciona em um array cada substring da url
                string[] aux = url.Split('/');
                // Verifica se existem parâmetros na URL e os remove caso existam
                if (aux[5].Contains("?"))  
                {
                    int index = aux[5].IndexOf("?");
                    var id = aux[5].Remove(index);
                    return id;
                }
                else if (aux[5].Contains("&"))
                {
                    int index = aux[5].IndexOf("&");
                    var id = aux[5].Remove(index);
                    return id;
                }
                return aux[5]; // id
            }
            else
            {
                throw new ArgumentException("URL em formato incorreto.");
            }
            #endregion
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
        }

    }
}

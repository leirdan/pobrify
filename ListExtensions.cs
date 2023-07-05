using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pobrify
{
    /// <summary>
    /// Representa métodos que não estão presentes na classe List mas são necessários para o programa.
    /// </summary>
    public static class ListExtensions
    {
        // Método de extensão: recurso que permite que um método extenda uma classe por meio da palavra-chave "this".
        // Assim, todo objeto do tipo List que for invocar o método AddMany não precisa passar o primeiro argumento, somente o segundo
        // (Já que o primeiro argumento se refere ao próprio objeto do tipo List<Album>.
        /// <summary>
        /// Adiciona vários itens ao fim de uma lista de álbuns.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="items"></param>
        public static void AddMany(this List<Album> list, params Album[] items)
        {
            foreach(Album album in items)
            {
                list.Add(album);
            }
        }
    }
}

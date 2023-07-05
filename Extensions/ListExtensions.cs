using System;
using System.Collections.Generic;

namespace pobrify.Extensions
{
    /// <summary>
    /// Representa métodos que não estão presentes na classe List mas são necessários para o programa.
    /// </summary>
    public static class ListExtensions { 
        // Método de extensão: recurso que permite que um método extenda uma classe por meio da palavra-chave "this".
        // Assim, todo objeto do tipo List que for invocar o método AddMany não precisa passar o primeiro argumento, somente o segundo
        // (Já que o primeiro argumento se refere ao próprio objeto do tipo List<Album>.
        /// <summary>
        /// Adiciona vários itens ao fim de uma lista de álbuns.
        /// </summary>
        /// <param name="list">Lista de objetos que invoca o método.</param>
        /// <param name="items">Itens do mesmo tipo da lista que serão adicionados nela.</param>
        public static void AddMany<T>(this List<T> list, params T[] items) where T : class 
        {
            foreach(T item in items)
            {
                list.Add(item);
            }
        }
    }
}

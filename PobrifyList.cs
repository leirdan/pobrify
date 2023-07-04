﻿using System;

/* Um tipo genérico diminui a redundância de código e permite concentrar métodos comuns a vários tipos (músicas, álbuns, playlists) em uma só classe.
   O tipo é definido no momento de compilação, somente.
 */
namespace pobrify
{
    /// <summary>
    /// Representa uma lista de objetos definidos pelo usuário do tipo Song, Album ou Playlist.
    /// </summary>
    // Aqui, é informado ao compilador que o tipo T é sempre uma classe, e assim é possível usar a referência nula dentro da classe.
    // Caso contrário, como um valor (int, bool, etc) não pode receber a referência nula, o código não compilaria.
    class PobrifyList<T> where T : class // T = Type
    {
        private T[] _items;
        private int _nextIndex = 0;
        public int _size = 0;

        /// <summary>
        /// Indexador, permite acessar os valores da lista de forma direta.
        /// </summary>
        /// <param name="index"></param>
        public T this[int index]
        {
            get { return _items[index]; }
            set
            {
                _size++;
                _items[index] = value as T;
            }
        }

        /// <summary>
        /// Construtor da lista que recebe somente o tamanho dela.
        /// </summary>
        /// <param name="range">Argumento opcional que representa o tamanho da lista de objetos; deve ser um valor maior que 0 para poder guardar um item. Tem por padrão o valor 5.</param>
        public PobrifyList(int range = 5)
        {
            if (range < 0)
            {
                throw new ArgumentOutOfRangeException("Tamanho inválido! Uma lista não pode ter 0 elementos.");
            }
            _items = new T[range];
        }
        /// <summary>
        /// Lista todos os objetos presentes na lista.
        /// </summary>
        public void Index()
        {
            Console.WriteLine("these are the songs you added:");
            foreach (T item in _items)
            {
                if (item != null)
                {
                    Console.WriteLine("informações do que quer q seja");
                }
            }
        }
        /// <summary>
        /// Retorna dados de um objeto específico com base no seu identificador.
        /// </summary>
        /// <param name="id">O ID ddo objeto; deve ser um número inteiro maior que 0.</param>
        /// <returns>Retorna o objeto que foi encontrada pelo ID ou um valor nulo, indicando que não há objeto com esse ID.</returns>
        public T FindById(int id)
        {
            try
            {
                if (V.VerifyId(id))
                {
                    return _items[id - 1];
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            return default;
        }

        /// <summary>
        /// Realiza a mudança de dados do objeto com base no identificador fornecido.
        /// </summary>
        /// <param name="id"> O ID do objeto; deve ser um número inteiro maior que 0.</param>
        public void Edit(int id)
        {
            try
            {
                if (V.VerifyId(id))
                {
                    //Console.WriteLine($"you will now modify the song '{_items[id - 1].Title}!'");
                    //Console.Write("please, insert the new song's title: ");
                    //var title = Console.ReadLine();
                    //Song s = new Song(id, title);

                    _items[id - 1] = null;
                    //_items[id - 1] = s;
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Remove o último objeto que foi inserido na lista.
        /// </summary>
        public void Delete()
        {
            _nextIndex = 1;
            _items[_items.Length - (_nextIndex)] = null;
            _nextIndex++;
        }

        /// <summary>
        /// Remove um objeto na lista com base em identificadores.
        /// </summary>
        /// <param name="id">Identificador do objeto.</param>
        // A palavra reservada params permite que seja passado um número variável de argumentos em uma matriz.
        public void Delete(params int[] id)
        {
            try
            {
                foreach (int i in id)
                {
                    if (V.VerifyId(i))
                    {
                        _items[i - 1] = null;
                    }
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}

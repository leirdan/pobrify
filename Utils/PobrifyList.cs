using System;

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
    class PobrifyList<T> where T : class, IPobrifyObject // T = Type
    {
        private readonly T[] _items;
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
            foreach (T item in _items)
            {
                if (item != null)
                {
                    if (item is SongContext song)
                    {
                        Console.WriteLine($"{song.Title}, ID {song.Id}");
                    }
                    else if (item is PlaylistContext playlist)
                    {
                        Console.WriteLine($"{playlist.Title}, ID {playlist.Id}");
                    }
                    else if (item is AlbumContext album)
                    {
                        Console.WriteLine($"{album.Title}, ID {album.Id}");
                    }
                }
            }
        }

        /// <summary>
        /// Retorna dados de um objeto específico com base no seu identificador.
        /// </summary>
        /// <param name="id">O ID do objeto; deve ser um número inteiro maior que 0.</param>
        /// <returns>Retorna o objeto que foi encontrada pelo ID ou um valor nulo, indicando que não há objeto com esse ID.</returns>
        public T FindById(int id)
        {
            try
            {
                if (VerifyId.Verify(id))
                {
                    return _items[id - 1];
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        /// <summary>
        /// Realiza a mudança de dados do objeto com base no identificador fornecido.
        /// </summary>
        /// <param name="id"> O ID do objeto; deve ser um número inteiro maior que 0.</param>
        public void Edit(int id, string title)
        {
            try
            {
                if (VerifyId.Verify(id))
                {
                    _items[id - 1].Id = id;
                    _items[id - 1].Title = title;
                }
                Index();
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        ///// <summary>
        ///// Remove o último objeto que foi inserido na lista.
        ///// </summary>
        //public void Delete()
        //{
        //    _nextIndex = 1;
        //    _items[_items.Length] = null;
        //    _nextIndex++;

        //    Index();
        //}

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
                    if (VerifyId.Verify(i))
                    {
                        if (i == 0)
                        {
                            _items[_items.Length] = null;
                        }
                        _items[i - 1] = null;
                    }
                }
                Index();
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}

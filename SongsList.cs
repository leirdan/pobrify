using System;

namespace pobrify
{
    /// <summary>
    /// Representa uma lista de músicas definidas pelo usuário.
    /// </summary>
    class SongsList
    {
        private Song[] _songs;
        private int _nextIndex = 0;
        public int _size = 0;

        /// <summary>
        /// Indexador, permite acessar a instância _songs[i] de forma direta, sem precisar declarar um método interno na classe (AddSong) para inserir valores.
        /// </summary>
        /// <param name="index"></param>
        public Song this[int index]
        {
            get { return _songs[index]; }
            set
            {
                _size++;
                _songs[index] = value;
            }
        }

        /// <summary>
        /// Construtor da lista que recebe somente o tamanho dela.
        /// </summary>
        /// <param name="range">Argumento opcional que representa o tamanho da lista de músicas; deve ser um valor maior que 0 para poder guardar um item. Tem por padrão o valor 5.</param>
        public SongsList(int range = 5)
        {
            if (range < 0)
            {
                throw new ArgumentOutOfRangeException("Tamanho inválido! Uma lista não pode ter 0 elementos.");
            }
            _songs = new Song[range];
        }
        /// <summary>
        /// Lista todas as músicas presentes na lista.
        /// </summary>
        public void ListSongs()
        {
            Console.WriteLine("these are the songs you added:");
            foreach (Song item in _songs)
            {
                if (item != null)
                {
                    Console.WriteLine($"{item.Title}, ID: {item.Id}");
                }
            }
        }
        /// <summary>
        /// Retorna dados de uma música específica com base no seu identificador.
        /// </summary>
        /// <param name="id">O ID da música; deve ser um número inteiro maior que 0.</param>
        /// <returns>Retorna a música que foi encontrada pelo ID ou um valor nulo, indicando que não há música com esse ID.</returns>
        public Song FindSong(int id)
        {
            try
            {
                if (Song.VerifyId(id))
                {
                    return _songs[id - 1];
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        /// <summary>
        /// Realiza a mudança do título de uma música com base no identificador fornecido.
        /// </summary>
        /// <param name="id"> O ID da música; deve ser um número inteiro maior que 0.</param>
        public void EditSong(int id)
        {
            try
            {
                if (Song.VerifyId(id))
                {
                    Console.WriteLine($"you will now modify the song '{_songs[id - 1].Title}!'");
                    Console.Write("please, insert the new song's title: ");
                    var title = Console.ReadLine();
                    Song s = new Song(id, title);

                    _songs[id - 1] = null;
                    _songs[id - 1] = s;
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Remove a última música que foi inserida na lista.
        /// </summary>
        public void RemoveSong()
        {
            _nextIndex = 1;
            _songs[_songs.Length - (_nextIndex)] = null;
            _nextIndex++;
        }

        /// <summary>
        /// Remove uma música na lista com base em identificadores.
        /// </summary>
        /// <param name="id">Identificador da música.</param>
        // A palavra reservada params permite que seja passado um número variável de argumentos em uma matriz.
        public void RemoveSong(params int[] id)
        {
            try
            {
                foreach (int i in id)
                {
                    if (Song.VerifyId(i))
                    {
                        _songs[i - 1] = null;
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

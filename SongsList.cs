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
            //foreach (var item in this._songs)
            //{
            //    Console.WriteLine($"{item.Title}, ID: {item.Id}");
            //}

            for (int i = 0; i < this._songs.Length; i++)
            {
                if (this._songs[i] == null)
                {
                }
                else
                {
                    Console.WriteLine($"{this._songs[i].Title}, ID: {this._songs[i].Id}");
                }
            }
        }
        /// <summary>
        /// Adiciona uma nova música na lista.
        /// </summary>
        /// <param name="song">Um objeto do tipo Song que deve ser passado.</param>
        /// <exception cref="FormatException">Lançada quando a cadeia de caracteres contém um caracter inválido.</exception>
        public void AddSong(Song song)
        {
            try
            {
                _songs[_nextIndex] = song;
                _nextIndex++;
                _size++;
            }
            catch (FormatException)
            {
                throw new FormatException();
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
        /// Remove uma música na lista com base no seu identificador.
        /// </summary>
        /// <param name="id">Identificador da música.</param>
        public void RemoveSong(int id)
        {
            try
            {
                if (Song.VerifyId(id))
                {
                    _songs[id - 1] = null;
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}

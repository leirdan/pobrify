﻿using System;

namespace pobrify
{
    public class Album : IPobrifyObject
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                if (VerifyId.Verify(value))
                {
                    _id = value;
                };
            }
        }
        public string Title { get; set; }

        public Album(int id, string title)
        {
            Id = id;
            Title = title;
        }

        // Herdado da interface IPobrifyObject, a qual herda a interface IComparable.
        // Útil para definir uma comparação personalizada.
        public int CompareTo(object obj)
        {
            // < 0: instância precede o obj
            // == 0: obj e instância são equivalentes
            // > 0: obj precede a instância
            try
            {
                var album = obj as Album; // conversão por "as" indica que, se a conversão não for possível, "album" será nulo.

                if (album == null)
                {
                    return -1;
                }

                if (this.Id < album.Id)
                {
                    return -1;
                }
                else if (this.Id > album.Id)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Parâmetro com erro", e.ParamName);
            }
            return 0;
        }
    }
}
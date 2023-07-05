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
                if (V.VerifyId(value))
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

    }
}

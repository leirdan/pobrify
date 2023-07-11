using System;

namespace pobrify
{
    interface IPobrifyObject : IComparable
    {
        int Id { get; set; }
        string Title { get; set; }
    }
}

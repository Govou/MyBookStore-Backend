using System.Collections.Generic;
using MyBookStore.Core.Entity;

namespace MyBookStore.Domain.Entities
{
    public class Author : Entity
    {
        public Author(string name)
        {
            Name = name;
            Books = new List<Book>();
        }

        public string Name { get; private set; }
        public virtual IEnumerable<Book> Books { get; private set; }
    }
}
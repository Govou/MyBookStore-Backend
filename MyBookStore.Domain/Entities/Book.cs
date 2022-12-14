using System;
using MyBookStore.Core.Entity;
using MyBookStore.Domain.Entities.Validators.Entities.ValueObjects;

namespace MyBookStore.Domain.Entities
{
    public class Book : Entity
    {
        public string Title { get; private set; }
        public Guid AuthorId { get; private set; }
        public Guid PublisherId { get; private set; }
        public bool IsDeleted { get; set; }

        public Publication Publication { get; private set; }
        public virtual Author Author { get; private set; }
        public virtual Publisher Publisher { get; private set; }


        public Book(string title, Guid authorId, Guid publisherId, Publication publication, Guid id, bool? isDeleted = null)
        {
            Title = title;
            AuthorId = authorId;
            PublisherId = publisherId;
            Publication = publication;
            Id = id;
            IsDeleted = isDeleted.HasValue ? isDeleted.Value : false;
        }

        protected Book()
        {            
        }
    }
}

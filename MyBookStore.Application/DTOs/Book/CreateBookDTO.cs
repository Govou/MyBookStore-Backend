using MyBookStore.Domain.Entities.Validators.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookStore.Application.DTOs.Book
{
    public class CreateBookDTO
    {
        public string Title { get; set; }
        public Guid AuthorId { get; set; }
        public Guid PublisherId { get; set; }
        public Publication Publication { get; set; }
    }
}

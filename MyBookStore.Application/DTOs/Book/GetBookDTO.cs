using MyBookStore.Application.DTOs.Author;
using MyBookStore.Application.DTOs.Publisher;
using MyBookStore.Domain.Entities.Validators.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookStore.Application.DTOs.Book
{
    public class GetBookDTO
    {
        public string Title { get; set; }
        public GetAuthorDTO Author { get; set; }
        public GetPublisherDTO Publisher { get; set; }
        public Publication Publication { get; set; }
    }
}

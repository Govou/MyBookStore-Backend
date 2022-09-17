using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookStore.Application.DTOs.Book
{
    public class UpdateBookDTO
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public int Edition { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookStore.Application.DTOs.Author
{
    public class GetAuthorDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }    
    }
}

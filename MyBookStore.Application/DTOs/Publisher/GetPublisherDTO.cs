using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookStore.Application.DTOs.Publisher
{
    public class GetPublisherDTO
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
    }
}

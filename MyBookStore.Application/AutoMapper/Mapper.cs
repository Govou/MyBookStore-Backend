using AutoMapper;
using MyBookStore.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using MyBookStore.Domain.Entities;
using System.Text;
using System.Threading.Tasks;
using MyBookStore.Application.DTOs.Publisher;
using MyBookStore.Application.DTOs.Author;

namespace MyBookStore.Application.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Domain.Entities.Author, GetAuthorDTO>();
            CreateMap<Domain.Entities.Publisher, GetPublisherDTO>();
        }
    }
}

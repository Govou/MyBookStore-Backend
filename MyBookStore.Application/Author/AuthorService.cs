using MyBookStore.Application.DTOs.Common;
using MyBookStore.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookStore.Application.Author
{
    public class AuthorService : IAuthorService
    {
        IAuthorRepository _repository;
        // private readonly IMapper _mapper;
        public AuthorService(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiCommonResponse> GetAllAuthors()
        {
            var result = new ApiCommonResponse();
            var authors = await _repository.GetAllAsync();

            if (authors.Count() > 0)
            {
                result = CommonResponse.Send(ResponseCodes.SUCCESS, authors, "records returned successfully");
            }
            else
            {
                result = CommonResponse.Send(ResponseCodes.FAILURE, null, "records failed to return");
            }
            return result;
        }
    }
}

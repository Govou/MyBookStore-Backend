using MyBookStore.Application.DTOs.Book;
using MyBookStore.Application.DTOs.Common;
using MyBookStore.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using MyBookStore.Domain.Entities.Validators.Entities.ValueObjects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookStore.Application.Book
{
    public class BookService : IBookService
    {
        IBookRepository _repository;
        // private readonly IMapper _mapper;
        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiCommonResponse> CreateBook(CreateBookDTO request)
        {
            var result = new ApiCommonResponse();
            var book = new Domain.Entities.Book(request.Title, request.AuthorId, request.PublisherId, request.Publication, Guid.NewGuid());
            var created = await _repository.Create(book);

            if (created)
            {
                result = CommonResponse.Send(ResponseCodes.SUCCESS, null, "record created successfully");
            }
            else
            {
                result = CommonResponse.Send(ResponseCodes.FAILURE, null, "record failed to delete");
            }
            return result;
        }

        public async Task<ApiCommonResponse> DeleteBook(Guid id)
        {
            var result = new ApiCommonResponse();
            var deleted = _repository.Delete(id);

            if (deleted != null)
            {
                result = CommonResponse.Send(ResponseCodes.SUCCESS, deleted, "record deleted successfully");
            }
            else
            {
                result = CommonResponse.Send(ResponseCodes.FAILURE, null, "record failed to delete");
            }
            return result;
        }

        public async Task<ApiCommonResponse> GetAllBooks()
        {
            var result = new ApiCommonResponse();
            var books = await _repository.GetAllAsync();

            if (books.Count() > 0)
            {
                result = CommonResponse.Send(ResponseCodes.SUCCESS, books, "records returned successfully");
            }
            else
            {
                result = CommonResponse.Send(ResponseCodes.FAILURE, null, "records failed to return");
            }
            return result;
        }

        public async Task<ApiCommonResponse> GetBookById(Guid id)
        {
            var result = new ApiCommonResponse();
            var book =  _repository.GetById(id);

            if (book != null)
            {
                result = CommonResponse.Send(ResponseCodes.SUCCESS, book, "record returned successfully");
            }
            else
            {
                result = CommonResponse.Send(ResponseCodes.FAILURE, null, "record failed to return");
            }
            return result;
        }

        public async Task<ApiCommonResponse> UpdateBook(UpdateBookDTO request)
        {
            var result = new ApiCommonResponse();
            var publication = new Publication(request.Edition, request.Year);
            var book = new Domain.Entities.Book(null, Guid.NewGuid(), Guid.NewGuid(),publication, Guid.NewGuid());
            var created = await _repository.Update(book);

            if (created)
            {
                result = CommonResponse.Send(ResponseCodes.SUCCESS, null, "record upfated successfully");
            }
            else
            {
                result = CommonResponse.Send(ResponseCodes.FAILURE, null, "record failed to update");
            }
            return result;
        }
    }
}

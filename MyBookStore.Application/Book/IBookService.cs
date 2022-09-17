using MyBookStore.Application.DTOs.Book;
using MyBookStore.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookStore.Application.Book
{
    public interface IBookService
    {
        Task<ApiCommonResponse> GetAllBooks();
        Task<ApiCommonResponse> GetBookById(Guid id);
        Task<ApiCommonResponse> CreateBook(CreateBookDTO request);
        Task<ApiCommonResponse> UpdateBook(UpdateBookDTO request);
        Task<ApiCommonResponse> DeleteBook(Guid id);
    }
}

using MyBookStore.Application.DTOs.Common;
using MyBookStore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookStore.Application.Publisher
{
    public class PublisherService : IPublisherService
    {
        IPublisherRepository _repository;
       // private readonly IMapper _mapper;
        public PublisherService(IPublisherRepository repository)
        {
            _repository = repository;
        }
        public async Task<ApiCommonResponse> GetAllPublishers()
        {
            var result = new ApiCommonResponse();
            var publishers = await _repository.GetAllAsync();

            if (publishers.Count() > 0)
            {
                result = CommonResponse.Send(ResponseCodes.SUCCESS, publishers, "records returned successfully");
            }
            else
            {
                result = CommonResponse.Send(ResponseCodes.FAILURE, null, "records failed to return");
            }
            return result;
        }
    }
}
